Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class CambioEstatusProductoForm

    Dim banderaGuardar As Integer = 2 ''Indica que no se ha realizado ninguna acción
    Dim msgExito As New ExitoForm
    Public Reactivar As Boolean = False

    Private Sub CambioEstatusProductoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarTablaModelos()
        llenarComboEstatus()


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_CAT_PROD", "CAMBIO_STATUS_PRODUCTO") Then
            PnlHabilitarBoton.Visible = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_CAT_PROD", "REACTIVAR_PRODUCTOS") Then
            Reactivar = True
        End If
    End Sub
    Public Sub llenarComboEstatus()
        Dim objProd As New Negocios.ProductosBU
        Dim dtDatosEstausProds As New DataTable
        dtDatosEstausProds = objProd.estatusProductos
        dtDatosEstausProds.Rows.InsertAt(dtDatosEstausProds.NewRow, 0)
        cmbEstatus.DataSource = dtDatosEstausProds
        cmbEstatus.ValueMember = "stpr_productoStatusId"
        cmbEstatus.DisplayMember = "stpr_descripcion"
    End Sub
    Public Sub llenarTablaModelos()
        Dim objModBU As New Negocios.ProductosBU
        Dim dtModelos As New DataTable
        dtModelos = objModBU.verModelosRegistrador()
        grdModelos.DataSource = dtModelos

        With grdModelos.DisplayLayout.Bands(0)
            .Columns("prod_codigo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prod_modelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Familia Ventas").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prod_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("grpo_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tica_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Subfamilia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("temp_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("piel_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("color_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fami_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("talla_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("plmu_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("forr_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("linea_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("suel_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("horma_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("pres_codSicy").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("stpr_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prod_codigo").Header.Caption = "Código"
            .Columns("prod_modelo").Header.Caption = "SICY"
            .Columns("prod_descripcion").Header.Caption = "Descripción"
            .Columns("grpo_descripcion").Hidden = True
            .Columns("modificado").Hidden = True
            .Columns("tica_descripcion").Header.Caption = "Tipo de Producto"
            .Columns("Familia Ventas").Header.Caption = "Familia de Ventas"
            .Columns("temp_nombre").Header.Caption = "Temporada"
            .Columns("piel_descripcion").Header.Caption = "Piel"
            .Columns("color_descripcion").Header.Caption = "Color"
            .Columns("fami_descripcion").Header.Caption = "Familia"
            .Columns("fami_descripcion").Hidden = True
            .Columns("Subfamilia").Hidden = True
            .Columns("stpr_productoStatusId").Hidden = True
            .Columns("pres_productoid").Hidden = True
            .Columns("pres_productoestiloid").Hidden = True
            .Columns("pres_estiloid").Hidden = True
            .Columns("linea_descripcion").Hidden = True
            .Columns("plmu_descripcion").Hidden = True
            .Columns("talla_descripcion").Header.Caption = "Corrida"
            .Columns("plmu_descripcion").Header.Caption = "Corte"
            .Columns("forr_descripcion").Header.Caption = "Forro"
            .Columns("forr_descripcion").Hidden = True
            .Columns("linea_descripcion").Header.Caption = "Linea"
            .Columns("suel_descripcion").Header.Caption = "Suela"
            .Columns("suel_descripcion").Hidden = True
            .Columns("horma_descripcion").Header.Caption = "Horma"
            .Columns("horma_descripcion").Hidden = True
            .Columns("pres_codSicy").Header.Caption = "Sicy"
            .Columns("stpr_descripcion").Header.Caption = "Estatus"
            .Columns("Seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Seleccion").Header.Caption = " "
            .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("Seleccion").Width = 1
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdModelos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdModelos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged

        For Each row As UltraGridRow In grdModelos.Rows
            row.Cells("Seleccion").Value = False
        Next
        If chkSeleccionar.Checked Then
            For Each row As UltraGridRow In grdModelos.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccion").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdModelos.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccion").Value = False
            Next
        End If

    End Sub

    Private Sub btnVerModelosDetalles_Click(sender As Object, e As EventArgs) Handles btnVerModelosDetalles.Click
        Try
            If cmbEstatus.SelectedValue > 0 Then
                Dim datos As New DataTable
                datos = grdModelos.DataSource
                Dim ban As Boolean = False
                For Each row As DataRow In datos.Rows
                    If CBool(row("Seleccion")) Then
                        ban = True
                        If validarCambioEstatus(row("stpr_descripcion"), cmbEstatus.Text) Then

                            If ValidarArticulosNoAutorizados(row("pres_productoestiloid")) = True Then
                                'Marco Arredondo - Validación para que al cambiar estatus valide que el modelo tenga número de modelo en SICY
                                If row("stpr_descripcion") = "MUESTRA" And cmbEstatus.SelectedValue = 3 Then

                                    If Not validarModeloSICY(row("prod_codigo")) Then
                                        Dim adv As New AdvertenciaForm
                                        adv.mensaje = "No se puede cambiar estatus. El modelo no cuenta con su código de modelo SICY."
                                        adv.ShowDialog()
                                        Exit Sub
                                    End If
                                End If

                                banderaGuardar = 0
                                row("modificado") = 1
                                row("stpr_descripcion") = cmbEstatus.Text
                                row("stpr_productoStatusId") = cmbEstatus.SelectedValue
                            Else
                                row("modificado") = 3

                            End If

                        Else
                            row("modificado") = 2
                        End If

                    End If
                Next


                If ban Then
                    grdModelos.DataSource = datos
                    pintarceldas()
                Else
                    Dim adv As New AdvertenciaForm
                    adv.mensaje = "Seleccione uno o varios artículos."
                    adv.ShowDialog()
                End If

            Else
                Dim adv As New AdvertenciaForm
                adv.mensaje = "Seleccione un estatus."
                adv.ShowDialog()
            End If

        Catch ex As Exception
            Dim adv As New AdvertenciaForm
            adv.mensaje = "Seleccione un estatus."
            adv.ShowDialog()
        End Try
    End Sub
    Public Sub pintarceldas()
        Dim i As Integer = 0
        Do
            If grdModelos.Rows(i).Cells("modificado").Value = 1 Then
                grdModelos.Rows(i).Appearance.BackColor = Color.YellowGreen
            End If
            If grdModelos.Rows(i).Cells("modificado").Value = 2 Then
                grdModelos.Rows(i).Appearance.BackColor = Color.Salmon
            End If
            If grdModelos.Rows(i).Cells("modificado").Value = 3 Then
                grdModelos.Rows(i).Appearance.BackColor = Color.Yellow

            End If
            i = i + 1
        Loop While i < grdModelos.Rows.Count
    End Sub
    Private Function validarModeloSICY(ByVal prod_codigo As String) As Boolean
        Dim obj As New Negocios.ProductosBU
        If obj.validarModeloSICY(prod_codigo) Then
            Return True
        End If

        Return False
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objAdvSalir As New ConfirmarForm
        Dim obj As New Negocios.ProductosBU
        objAdvSalir.mensaje = "¿Está seguro de guardar los cambios?"
        If objAdvSalir.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Dim datos As New DataTable
            datos = grdModelos.DataSource

            For Each row As DataRow In datos.Rows
                If row("modificado") = 1 Then
                    obj.actualizarEstatus(row("pres_productoid"), row("pres_estiloid"), row("pres_productoEstiloId"), row("stpr_productoStatusId"))
                End If
            Next

            banderaGuardar = 1
            Me.Cursor = Cursors.Default
            msgExito.mensaje = "El cambio se realizó con éxito."
            msgExito.ShowDialog()
            Me.Cursor = Cursors.WaitCursor
            llenarTablaModelos()
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If banderaGuardar = 0 Then
            Me.Close()
        ElseIf banderaGuardar = 2 Or banderaGuardar = 1 Then
            Me.Close()
        End If

    End Sub

    Private Sub CambioEstatusProductoForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If banderaGuardar = 0 Then
            Dim objAdvSalir As New ConfirmarForm
            objAdvSalir.mensaje = "¿Está seguro de salir sin guardar los cambios?"
            If objAdvSalir.ShowDialog() = Windows.Forms.DialogResult.OK Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Function validarCambioEstatus(deEstatus As String, aEstatus As String)
        If Reactivar = True Then
            Return True

        Else
            If deEstatus = "PROTOTIPO" Then
                If aEstatus = "MUESTRA" Or aEstatus = "NO AUTORIZADO" Then
                    Return True
                Else
                    Return False
                End If
            End If
            If deEstatus = "MUESTRA" Then
                If aEstatus = "NO AUTORIZADO" Or aEstatus = "AUTORIZADO PARA PROGRAMACIÓN" Then
                    Return True
                Else
                    Return False
                End If
            End If
            If deEstatus = "NO AUTORIZADO" Then
                If aEstatus = "PROTOTIPO" Or aEstatus = "MUESTRA" Then
                    Return True
                Else
                    Return False
                End If
            End If
            If deEstatus = "AUTORIZADO PARA PROGRAMACIÓN" Then
                If aEstatus = "NO AUTORIZADO" Or aEstatus = "AUTORIZADO PARA PRODUCCIÓN" Then
                    Return True
                Else
                    Return False
                End If
            End If
            If deEstatus = "AUTORIZADO PARA PRODUCCIÓN" Then
                If aEstatus = "DESCONTINUADO PARA PRODUCCIÓN" Then
                    Return True
                Else
                    Return False
                End If
            End If
            If deEstatus = "DESCONTINUADO PARA PRODUCCIÓN" Then
                If aEstatus = "DESCONTINUADO PARA VENTA" Then
                    Return True
                Else
                    Return False
                End If
            End If
            If deEstatus = "DESCONTINUADO PARA VENTA" Then
                If aEstatus = "DESCONTINUADO PARA PRODUCCIÓN" Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If

        'If Reactivar = True Then
        '    If deEstatus = "DESCONTINUADO PARA PRODUCCIÓN" Then
        '        If aEstatus = "DESCONTINUADO PARA VENTA" Or aEstatus = "AUTORIZADO PARA PRODUCCIÓN" Then
        '            Return True
        '        Else
        '            Return False
        '        End If
        '    End If
        '    If deEstatus = "DESCONTINUADO PARA VENTA" Then
        '        If aEstatus = "DESCONTINUADO PARA PRODUCCIÓN" Or aEstatus = "AUTORIZADO PARA PRODUCCIÓN" Then
        '            Return True
        '        Else
        '            Return False
        '        End If
        '    End If
        'Else
        '    If deEstatus = "DESCONTINUADO PARA PRODUCCIÓN" Then
        '        If aEstatus = "DESCONTINUADO PARA VENTA" Then
        '            Return True
        '        Else
        '            Return False
        '        End If
        '    End If
        '    If deEstatus = "DESCONTINUADO PARA VENTA" Then
        '        If aEstatus = "DESCONTINUADO PARA PRODUCCIÓN" Then
        '            Return True
        '        Else
        '            Return False
        '        End If
        '    End If
        'End If

        Return False
    End Function

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        llenarTablaModelos()
        Me.Cursor = Cursors.Default
    End Sub

    Public Function ValidarArticulosNoAutorizados(ProductoEstiloId As Integer) As Boolean

        Dim objPBU As New Programacion.Negocios.ProductosBU

        If ProductoEstiloId <> 0 Then
            Return objPBU.ValidarArticuloEnPedidoActivo(ProductoEstiloId.ToString)
        Else
            Return True
        End If


    End Function

    Private Sub btnActualizarDescontinuados_Click(sender As Object, e As EventArgs) Handles btnActualizarDescontinuados.Click
        Dim objModBU As New Negocios.ProductosBU
        Dim objMensajeConfirmacion As New ExitoForm
        Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Me.Cursor = Cursors.WaitCursor
        objModBU.CambiarStatusAProductos(UsuarioID)
        grdModelos.DataSource = Nothing
        llenarTablaModelos()
        objMensajeConfirmacion.mensaje = "Se actualizó correctamente."
        objMensajeConfirmacion.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub
End Class