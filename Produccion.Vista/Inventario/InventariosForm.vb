Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Entidades
Imports Tools
Imports Infragistics.Win
Imports Programacion.Vista

Public Class InventariosForm
    Dim adv As New AdvertenciaForm
    Dim listaInicial As New List(Of String)
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub InventariosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarControles()
    End Sub
    Public Sub cargarControles()
        cargarPermisos()
        llenarComboNaves()
        'llenarComboMaterial()
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Public Sub llenarGrid()
        Try
            Dim obj As New InventarioBU
            Dim datos As New DataTable
            'Dim idClas As Integer = 0
            'If cmbMaterial.SelectedIndex > 0 Then
            '    idClas = cmbMaterial.SelectedValue
            'End If
            Dim FClasificacion As String = String.Empty
            FClasificacion = ObtenerFiltrosGrid(grdClasificacion)

            datos = obj.getDatosInventario(cmbNave.SelectedValue, FClasificacion, dtpFechaInicio.Value)
            grdMateriales.DataSource = getDatosEntradasSalidas(datos)
            setDiseñoGrid()
            getTotalGrid()
        Catch ex As Exception
        End Try
    End Sub
    Function getDatosEntradasSalidas(ByVal datos As DataTable) As DataTable
        Dim obj As New InventarioBU
        Dim datosEntradasSalidas As New DataTable
        For Each row As DataRow In datos.Rows
            row("SUBTOTAL") = row("PRECIO") * row("INVENTARIO")
        Next
        Return datos
    End Function
    Public Sub setDiseñoGrid()
        Try
            With grdMateriales.DisplayLayout.Bands(0)
                .Columns("SUBTOTAL").Format = "$ ##,##0.00"
                .Columns("SUBTOTAL").Header.Caption = "SUBTOTAL"
                .Columns("PRECIO").Header.Caption = "PRECIO"
                .Columns("INVENTARIOFINAL").Header.Caption = "INVENTARIO FINAL"
                .Columns("PRECIO").Format = "$ ##,##0.00"
                .Columns("INVENTARIO").Format = "##,##0.00"
                .Columns("INVENTARIOFINAL").Format = "##,##0.00"
                .Columns("UMC").Width = 60
                .Columns("MATERIAL").Width = 300
                .Columns("PROVEEDOR").Width = 300
                .Columns("CLASIFICACIÓN").Width = 100
                .Columns("invn_materialnaveid").Hidden = True
                .Columns("invn_proveedorid").Hidden = True
                .Columns("invn_naveid").Hidden = True
                .Columns("nave_nombre").Hidden = True
                .Columns("invn_factorconversion").Hidden = True
                .Columns("mate_materialid").Hidden = True
                .Columns("invn_ump").Hidden = True
                .Columns("invn_umc").Hidden = True
                .Columns("INVENTARIOFINAL").Hidden = False
                .Columns("SUBTOTAL").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("PRECIO").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("INVENTARIO").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("INVENTARIOFINAL").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("IdMoneda").Hidden = True
            End With
            grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdMateriales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
            grdMateriales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        Catch ex As Exception

        End Try

    End Sub
    Public Sub getTotalGrid()
        Try
            Dim datos As New DataTable
            datos = grdMateriales.DataSource
            Dim list As New List(Of UnidadesDeMedida)
            Dim list2 As New List(Of UnidadesDeMedida)
            Dim u As New UnidadesDeMedida
            Dim total As Double = 0
            For Each row As DataRow In datos.Rows
                total += CDbl(row("SUBTOTAL"))
                u = New UnidadesDeMedida
                u.nombreUnidad = row("UMC")
                u.total = row("INVENTARIO")
                list.Add(u)
            Next
            lblDinero.Text = total.ToString("$ ##,##0.00")

            For Each p As UnidadesDeMedida In list
                list2 = agregarTotal(list2, p.nombreUnidad, p.total)
            Next
            lblTotalInv.Text = ""
            Dim i As Integer = 0
            For Each p As UnidadesDeMedida In list2

                If i = list2.Count - 1 Then
                    lblTotalInv.Text += p.total.ToString("##,##0.00") & " " & p.nombreUnidad
                Else
                    lblTotalInv.Text += p.total.ToString("##,##0.00") & " " & p.nombreUnidad & "/ "
                End If
                i += 1
            Next
        Catch ex As Exception
        End Try
    End Sub
    Function agregarTotal(list As List(Of UnidadesDeMedida), umc As String, total As Double)

        Dim u As New UnidadesDeMedida
        u.nombreUnidad = umc
        u.total = total
        Dim entro As Boolean = False
        For Each p As UnidadesDeMedida In list
            If umc = p.nombreUnidad Then
                p.total += total
                entro = True
            End If
        Next
        If entro = False Then
            list.Add(u)
        End If
        Return list

    End Function
    'Public Sub llenarComboMaterial()
    '    Dim obj As New InventarioBU
    '    Dim lst As New DataTable
    '    lst = obj.getClasificaciones
    '    If Not lst.Rows.Count = 0 Then
    '        lst.Rows.InsertAt(lst.NewRow, 0)
    '        cmbMaterial.DataSource = lst
    '        cmbMaterial.DisplayMember = "clasificacion"
    '        cmbMaterial.ValueMember = "id"
    '    End If
    'End Sub
    Public Sub llenarComboNaves()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.Items.Count = 2 Then
            cmbNave.SelectedIndex = 1
        End If
    End Sub
    Public Sub cargarPermisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Inventario Materiales", "VERDETALLES") Then
            pnlDetalle.Visible = True
        Else
            pnlDetalle.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Inventario Materiales", "MOVIMIENTOS") Then
            pnlMovimientos.Visible = True
        Else
            pnlMovimientos.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Inventario Materiales", "REPORTEPROVEEDOR") Then
            pnlReporte.Visible = True
        Else
            pnlReporte.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Inventario Materiales", "EXPORTAR") Then
            pnlExportar.Visible = True
        Else
            pnlExportar.Visible = False
        End If

    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdMateriales.DataSource = Nothing
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

                ultExportGrid.Export(grdMateriales, fileName)

                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub actualizarTabla()
        Try
            'Si aparencen dos registros aparentemente repetidos posiblemente el factor de conversion son diferentes
            If cmbNave.SelectedValue > 0 Then
                llenarGrid()
            Else
                adv.mensaje = "Selecciona una nave."
                adv.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        actualizarTabla()
    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If grdMateriales.Rows.Count > 0 Then
            ExportarGridAExcel()
        End If
    End Sub
    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click

        Try
            If grdMateriales.ActiveRow.Selected = True Then
                Dim form As New InventarioDetalleForm
                With form
                    .idProveedor = grdMateriales.ActiveRow.Cells("invn_proveedorid").Value
                    .idMaterialNave = grdMateriales.ActiveRow.Cells("invn_materialnaveid").Value
                    .precio = grdMateriales.ActiveRow.Cells("PRECIO").Value
                    .material = grdMateriales.ActiveRow.Cells("MATERIAL").Value
                    .proveedor = grdMateriales.ActiveRow.Cells("PROVEEDOR").Value
                    .inventarioTotal = grdMateriales.ActiveRow.Cells("INVENTARIOFINAL").Value
                    .totalDinero = grdMateriales.ActiveRow.Cells("SUBTOTAL").Value
                End With
                form.ShowDialog()
            Else
                adv.mensaje = "Selecciona un material"
                adv.ShowDialog()
            End If
        Catch ex As Exception
        End Try


    End Sub
    Private Sub btnMovimientos_Click(sender As Object, e As EventArgs) Handles btnMovimientos.Click
        Try
            If grdMateriales.ActiveRow.Selected = True Then
                Dim form As New MovimientosInventarioForm
                Dim p As New InventarioNave
                With p
                    .naveid = grdMateriales.ActiveRow.Cells("invn_naveid").Value
                    .materialnaveid = grdMateriales.ActiveRow.Cells("invn_materialnaveid").Value
                    .nombreNave = grdMateriales.ActiveRow.Cells("nave_nombre").Value
                    .precio = grdMateriales.ActiveRow.Cells("PRECIO").Value
                    .proveedorid = grdMateriales.ActiveRow.Cells("invn_proveedorid").Value
                    .inventarioinicial = grdMateriales.ActiveRow.Cells("INVENTARIOFINAL").Value
                    .factorconversion = grdMateriales.ActiveRow.Cells("invn_factorconversion").Value
                    .umc = grdMateriales.ActiveRow.Cells("invn_umc").Value
                    .ump = grdMateriales.ActiveRow.Cells("invn_ump").Value
                    .totalDinero = grdMateriales.ActiveRow.Cells("PRECIO").Value * grdMateriales.ActiveRow.Cells("INVENTARIOFINAL").Value
                    .nombreMaterial = grdMateriales.ActiveRow.Cells("MATERIAL").Value
                    .umcMaterial = grdMateriales.ActiveRow.Cells("UMC").Value
                    .monedaid = grdMateriales.ActiveRow.Cells("IdMoneda").Value
                End With
                form.datos = p
                form.ShowDialog()
                actualizarTabla()
            Else
                adv.mensaje = "Selecciona un registro."
                adv.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        If cmbNave.SelectedIndex > 0 Then
            Dim form As New ReporteInventarioForm
            form.idNave = cmbNave.SelectedValue
            form.ShowDialog()
        Else
            adv.mensaje = "Seleccione una nave."
            adv.ShowDialog()
        End If

    End Sub
    Private Sub grdMateriales_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdMateriales.ClickCell
        Try
            grdMateriales.ActiveRow.Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        Try
            grdMateriales.DataSource = Nothing
            lblDinero.Text = ""
            lblTotalInv.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs)
        Try
            grdMateriales.DataSource = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        Try
            grdMateriales.DataSource = Nothing
            lblDinero.Text = ""
            lblTotalInv.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMaterial_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            grdMateriales.DataSource = Nothing
            lblDinero.Text = ""
            lblTotalInv.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdClasificacion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClasificacion.InitializeLayout
        grid_diseño(grdClasificacion)
        grdClasificacion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clasificación"
    End Sub

    Private Sub grdClasificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdClasificacion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdClasificacion.DeleteSelectedRows(False)
    End Sub

    Private Sub btnClasificacion_Click(sender As Object, e As EventArgs) Handles btnClasificacion.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 16

        For Each row As UltraGridRow In grdClasificacion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdClasificacion.DataSource = listado.listParametros
        With grdClasificacion
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Clasificación"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
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

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub

    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        Return Resultado
    End Function

    Private Sub btnLimpiarClasificacion_Click(sender As Object, e As EventArgs) Handles btnLimpiarClasificacion.Click
        grdClasificacion.DataSource = listaInicial
    End Sub
End Class