Imports Infragistics.Win.UltraWinGrid

Public Class AsignaArticuloNaveForm
    Dim msjError As New Tools.AdvertenciaForm
    Dim msjExito As New Tools.ExitoForm
    Dim confirmacion As New Tools.ConfirmarForm
    Dim objCargaEquivalenciaBU As New Programacion.Negocios.CargaEquivalenciaBU
    Dim objNaveProductoBU As New Programacion.Negocios.CargaNaveArticuloBU


    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        ExportarGridAExcel()
    End Sub

    Private Sub AsignaArticuloNaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarNaves()
        uccFechaIni.Value = Date.Now
        uccFechaFin.Value = Date.Now
        If Not (Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_SIM_ARTICULOSNAVE", "ASIGNAR_ARTICULOS")) Then
            btnAgregarColeccion.Enabled = False
            btnQuitarColeccion.Enabled = False
            btnGuardar.Enabled = False
        End If

    End Sub
    Private Sub ExportarGridAExcel()

        Dim sfd As New SaveFileDialog
        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor

                ultExportGrid.Export(grdProductosNuevos, fileName)

                Dim objMensajeExito As New Tools.ExitoForm
                msjError.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                msjError.StartPosition = FormStartPosition.CenterScreen
                msjError.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                msjError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                msjError.StartPosition = FormStartPosition.CenterScreen
                msjError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub llenarNaves()
        Dim dt As DataTable
        dt = objCargaEquivalenciaBU.CargaCatalogoNaveBases()
        If validaTabla(dt) Then
            cmbNave.DataSource = dt
            cmbNave.DisplayMember = "nave_nombre"
            cmbNave.ValueMember = "nave_naveid"
        Else
            msjError.mensaje = "No existen registros de naves para este usuario"
            msjError.ShowDialog()
        End If

    End Sub

#Region "General"
    Private Function validaTabla(ByVal tabla As DataTable) As Boolean
        Dim respuesta As Boolean = True
        If tabla Is Nothing Then
            respuesta = False
        Else

            If tabla.Rows Is Nothing Then
                respuesta = False
            Else
                If tabla.Rows.Count = 0 Then
                    respuesta = False
                Else
                    respuesta = True
                End If
            End If
        End If
       
        Return respuesta
    End Function
#End Region

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        LlenarInfo()
    End Sub
    Private Sub LlenarInfo()
        If cmbNave.SelectedValue Is Nothing Then
            msjError.mensaje = "Debe seleccionar Nave para realizar esta acción"
            msjError.ShowDialog()
            Exit Sub
        End If
        Dim objNaveArticulo As New Programacion.Negocios.CargaNaveArticuloBU
        Dim dtAsignados As DataTable = Nothing
        Dim dtNoAsignados As DataTable = Nothing

        dtAsignados = objNaveArticulo.CargarAsignados(cmbNave.SelectedValue)
        dtNoAsignados = objNaveArticulo.CargarNoAsignados(cmbNave.SelectedValue)

        If validaTabla(dtAsignados) Or validaTabla(dtNoAsignados) Then
            grdProductosAsigandos.DataSource = dtAsignados
            grdProductosNuevos.DataSource = dtNoAsignados

            grdProductosAsigandos.DisplayLayout.Bands(0).Columns("marc_marcaid").Hidden = True
            grdProductosAsigandos.DisplayLayout.Bands(0).Columns("cole_coleccionid").Hidden = True
            grdProductosAsigandos.DisplayLayout.Bands(0).Columns("pres_productoestiloid").Hidden = True
            grdProductosAsigandos.DisplayLayout.Bands(0).Columns("prod_productoid").Hidden = True
            grdProductosAsigandos.DisplayLayout.Bands(0).Columns("FechaInicioProduccion").Hidden = True
            grdProductosAsigandos.DisplayLayout.Bands(0).Columns("Cambio").Hidden = True

            grdProductosNuevos.DisplayLayout.Bands(0).Columns("marc_marcaid").Hidden = True
            grdProductosNuevos.DisplayLayout.Bands(0).Columns("cole_coleccionid").Hidden = True
            grdProductosNuevos.DisplayLayout.Bands(0).Columns("pres_productoestiloid").Hidden = True
            grdProductosNuevos.DisplayLayout.Bands(0).Columns("prod_productoid").Hidden = True
            grdProductosNuevos.DisplayLayout.Bands(0).Columns("FechaInicioProduccion").Hidden = True
            grdProductosNuevos.DisplayLayout.Bands(0).Columns("Cambio").Hidden = True
            grdProductosNuevos.DisplayLayout.Bands(0).Columns("Prioridad").Hidden = True

            For Each col As UltraGridColumn In grdProductosNuevos.Rows.Band.Columns
                If col.Header.Caption.Contains("Consecutivo") = False And col.Header.Caption.Contains("Fecha") = False Then
                    col.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
                End If

            Next

            For Each col As UltraGridColumn In grdProductosAsigandos.Rows.Band.Columns
                If col.Header.Caption.Contains("Consecutivo") = False And col.Header.Caption.Contains("Fecha") = False And col.Header.Caption.Contains("Prioridad") = False Then
                    col.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
                End If

            Next


        Else
            msjError.mensaje = "No se encontraron artículos de esta Nave"
            msjError.ShowDialog()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        confirmacion.mensaje = "¿Esta seguro de limpiar los artículos?"
        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            grdProductosAsigandos.DataSource = Nothing
            grdProductosNuevos.DataSource = Nothing
        End If

    End Sub

    Private Sub btnAgregarColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarColeccion.Click
        Dim tablaSeleccionados As DataTable = Nothing
        Dim tablaAsignados As DataTable = Nothing
        Dim arregloRows() As DataRow = Nothing
        Dim arregloRowsNew() As DataRow = Nothing
        tablaSeleccionados = grdProductosNuevos.DataSource
        tablaAsignados = grdProductosAsigandos.DataSource
        If validaTabla(tablaSeleccionados) Then
            arregloRows = tablaSeleccionados.Select("Marcar=1")
        Else
            Exit Sub
        End If
        If arregloRows.Length > 0 Then
            For Each row As DataRow In arregloRows
                Dim fila As DataRow = tablaAsignados.NewRow()
                fila("Marcar") = False
                fila("Consecutivo") = row("Consecutivo")
                fila("marc_marcaid") = row("marc_marcaid")
                fila("Marca") = row("Marca")
                fila("cole_coleccionid") = row("cole_coleccionid")
                fila("Colección") = row("Colección")
                fila("pres_productoestiloid") = row("pres_productoestiloid")
                fila("prod_productoid") = row("prod_productoid")
                fila("Modelo") = row("Modelo")
                fila("Piel_Color") = row("Piel_Color")
                fila("Corrida") = row("Corrida")
                fila("Naves") = row("Naves")
                fila("Prioridad") = row("Prioridad")

                If chkFechas.Checked Then
                    fila("FechaFinProduccion") = DBNull.Value
                    fila("FechaInicioProduccion") = DBNull.Value
                Else
                    If Not row("FechaFinProduccion") Is DBNull.Value Then
                        If row("FechaFinProduccion").ToString() = "" Or row("FechaFinProduccion") = Date.Parse("01/01/1900") Then
                            fila("FechaInicioProduccion") = uccFechaIni.Value
                        Else
                            fila("FechaInicioProduccion") = row("FechaInicioProduccion")
                        End If
                    Else
                        fila("FechaInicioProduccion") = uccFechaIni.Value
                    End If

                    fila("FechaFinProduccion") = uccFechaFin.Value
                End If

                fila("Cambio") = True
                tablaAsignados.Rows.Add(fila)
                tablaSeleccionados.Rows.Remove(row)
            Next
        End If
        grdProductosAsigandos.DataSource = tablaAsignados
        grdProductosNuevos.DataSource = tablaSeleccionados
    End Sub

    Private Sub btnQuitarColeccion_Click(sender As Object, e As EventArgs) Handles btnQuitarColeccion.Click
        Dim tablaSeleccionados As DataTable = Nothing
        Dim tablaAsignados As DataTable = Nothing
        Dim arregloRows() As DataRow = Nothing
        Dim arregloRowsNew() As DataRow = Nothing
        tablaSeleccionados = grdProductosNuevos.DataSource
        tablaAsignados = grdProductosAsigandos.DataSource
        If validaTabla(tablaAsignados) Then
            arregloRows = tablaAsignados.Select("Marcar=1")
        Else
            Exit Sub
        End If
        If arregloRows.Length > 0 Then
            For Each row As DataRow In arregloRows
                Dim fila As DataRow = tablaSeleccionados.NewRow()
                fila("Marcar") = False
                fila("Consecutivo") = row("Consecutivo")
                fila("marc_marcaid") = row("marc_marcaid")
                fila("Marca") = row("Marca")
                fila("cole_coleccionid") = row("cole_coleccionid")
                fila("Colección") = row("Colección")
                fila("pres_productoestiloid") = row("pres_productoestiloid")
                fila("prod_productoid") = row("prod_productoid")
                fila("Modelo") = row("Modelo")
                fila("Piel_Color") = row("Piel_Color")
                fila("Corrida") = row("Corrida")
                fila("Naves") = row("Naves")
                fila("Prioridad") = row("Prioridad")
                If chkFechas.Checked Then
                    fila("FechaFinProduccion") = DBNull.Value
                    fila("FechaInicioProduccion") = DBNull.Value
                Else
                    If Not row("FechaInicioProduccion") Is DBNull.Value Then
                        If row("FechaInicioProduccion").ToString() = "" Or row("FechaInicioProduccion") = Date.Parse("01/01/1900") Then
                            fila("FechaInicioProduccion") = uccFechaIni.Value
                        Else
                            fila("FechaInicioProduccion") = Today.Date()
                        End If
                    Else
                        fila("FechaInicioProduccion") = uccFechaIni.Value
                    End If
                    If Not row("FechaFinProduccion") Is DBNull.Value Then
                        If row("FechaFinProduccion").ToString() = "" Or row("FechaFinProduccion") = Date.Parse("01/01/1900") Then
                            fila("FechaFinProduccion") = uccFechaFin.Value
                        Else
                            fila("FechaFinProduccion") = Today.Date()
                        End If
                    Else
                        fila("FechaFinProduccion") = uccFechaFin.Value
                    End If
                End If


                fila("Cambio") = True
                tablaSeleccionados.Rows.Add(fila)
                tablaAsignados.Rows.Remove(row)
            Next
        End If
        grdProductosAsigandos.DataSource = tablaAsignados
        grdProductosNuevos.DataSource = tablaSeleccionados
    End Sub

    Private Sub chkSeleccionarArts_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarArts.CheckedChanged
        Dim tbSeleccionados As DataTable
        tbSeleccionados = grdProductosNuevos.DataSource
        If chkSeleccionarArts.Checked Then
            For Each row As UltraGridRow In grdProductosNuevos.Rows.GetFilteredInNonGroupByRows
                'row.Cells("Marcar").Value = True
                tbSeleccionados.Rows(row.Index)("Marcar") = True
            Next
        Else
            For Each row As UltraGridRow In grdProductosNuevos.Rows.GetFilteredInNonGroupByRows
                'row.Cells("Marcar").Value = False
                tbSeleccionados.Rows(row.Index)("Marcar") = False
            Next
        End If
    End Sub

    Private Sub chkAsignados_CheckedChanged(sender As Object, e As EventArgs) Handles chkAsignados.CheckedChanged
        Dim tbAsignados As DataTable
        tbAsignados = grdProductosAsigandos.DataSource
        If chkAsignados.Checked Then
            For Each row As UltraGridRow In grdProductosAsigandos.Rows.GetFilteredInNonGroupByRows
                tbAsignados.Rows(row.Index)("Marcar") = True
            Next
        Else
            For Each row As UltraGridRow In grdProductosAsigandos.Rows.GetFilteredInNonGroupByRows
                tbAsignados.Rows(row.Index)("Marcar") = False
            Next
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim dtAsignados As DataTable = Nothing
        Dim dtSeleccionados As DataTable = Nothing
        Dim prioridad As Integer = 1


        Dim dtAsignadosCambio As DataTable
        Dim dtSeleccionadosCambio As DataTable

        dtAsignados = grdProductosAsigandos.DataSource
        dtSeleccionados = grdProductosNuevos.DataSource

        If chkFechas.Checked = False Then
            If uccFechaIni.Value > uccFechaFin.Value Then
                msjError.mensaje = "La fecha de inicio no debe ser mayor a la fecha fin"
                msjError.ShowDialog()
                Exit Sub
            End If
        End If


        If rdbUltima.Checked Then
            prioridad = 2
        End If

        Dim valida As Integer = 0

        Dim respuesta As Boolean = True
        If validaTabla(dtAsignados) Then
            If dtAsignados.Select("Cambio = 1").Length > 0 Then
                dtAsignadosCambio = dtAsignados.Select("Cambio = 1").CopyToDataTable
                If validaTabla(dtAsignadosCambio) Then
                    If chkFechas.Checked = False Then
                        If Today.Date > uccFechaFin.Value Then
                            msjError.mensaje = "La fecha fin de producción debe ser mayor a la fecha actual"
                            msjError.ShowDialog()
                            Exit Sub
                        End If
                    End If
                    If Not objNaveProductoBU.InsertarModificarNaveProductos(dtAsignados, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue, prioridad) Then
                        respuesta = False
                    End If
                End If
            Else
                valida = valida + 1
            End If
        End If

        If validaTabla(dtSeleccionados) Then
            If dtSeleccionados.Select("Cambio = 1").Length > 0 Then
                dtSeleccionadosCambio = dtSeleccionados.Select("Cambio = 1").CopyToDataTable
                If validaTabla(dtSeleccionadosCambio) Then
                    If Not objNaveProductoBU.InsertarModificarNaveProductos(dtSeleccionadosCambio, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue, prioridad) Then
                        respuesta = False
                    End If
                End If
            Else
                valida = valida + 1
            End If
        End If

        If valida = 2 Then
            msjError.mensaje = "No existe información seleccionada para guardar"
            msjError.ShowDialog()
            Exit Sub
        End If
        If respuesta Then
            msjExito.mensaje = "La información se guardo correctamente"
            msjExito.ShowDialog()
            LlenarInfo()
        Else
            msjError.mensaje = "Existen errores en el guardado" & vbNewLine & "No toda la información se guardado"
            msjError.ShowDialog()
        End If

    End Sub

    Private Sub chkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechas.CheckedChanged
        'Dim tbSeleccionados As DataTable
        'tbSeleccionados = grdProductosNuevos.DataSource
        'If chkFechas.Checked Then
        '    For Each row As DataRow In tbSeleccionados.Rows
        '        If row("FechaFinProduccion") Is DBNull.Value Then
        '            row("Marcar") = True
        '        End If
        '    Next
        'Else
        '    For Each row As DataRow In tbSeleccionados.Rows
        '        If row("FechaFinProduccion") Is DBNull.Value Then
        '            row("Marcar") = False
        '        End If
        '    Next
        'End If
    End Sub

    Private Sub grdProductosAsigandos_CellDataError(sender As Object, e As Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs) Handles grdProductosAsigandos.CellDataError
        Dim grid As UltraGrid = CType(sender, UltraGrid)

        Dim celda As UltraGridCell = grid.ActiveCell
        If Not celda Is Nothing And celda.Column.Header.Caption = "Prioridad" Then
            e.RaiseErrorEvent = False
            msjError.mensaje = "El valor de Prioridad no es valido, revise la información"
            msjError.ShowDialog()
        End If
    End Sub

    Private Sub grdProductosAsigandos_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdProductosAsigandos.AfterCellUpdate
        If e.Cell.Column.Header.Caption = "Prioridad" Then
            Dim numero As Integer = 0
            Dim strValor As String = e.Cell.Value.ToString
            Dim str As String = e.Cell.Row.Index.ToString()
            e.Cell.Row.Cells("Cambio").Value = True
            Try
                numero = Integer.Parse(e.Cell.Value.ToString)
            Catch ex As Exception
                e.Cell.Value = numero
                msjError.mensaje = "El valor de Prioridad debe ser numérico"
                msjError.ShowDialog()
                e.Cell.CancelUpdate()
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class