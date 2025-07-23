Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Tools

Public Class DatosImportConsumos
    Public datos As New DataTable
    Public idNave As Integer = 0
    Public productoEstiloId As Integer = 0
    Public guardar As Boolean = True
    Dim adv As New AdvertenciaForm
    Public consumos As New DataTable
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub DatosImportConsumos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datos.Columns.Add("Validación", Type.GetType("System.String"))
        datos.Columns.Add("Activo", Type.GetType("System.Int32"))
        datos.Columns.Add("ComponenteDes", Type.GetType("System.String"))
        datos.Columns.Add("ProveedorDes", Type.GetType("System.String"))
        datos.Columns.Add("idMaterialNave", Type.GetType("System.Int32"))
        datos.Columns.Add("ClasificacionDes", Type.GetType("System.String"))
        datos.Columns.Add("idClasificacion", Type.GetType("System.Int32"))
        datos.Columns.Add("UMC", Type.GetType("System.String"))
        datos.Columns.Add("UMP", Type.GetType("System.String"))
        datos.Columns.Add("idUMC", Type.GetType("System.Int32"))
        datos.Columns.Add("idUMProd", Type.GetType("System.Int32"))
        datos.Columns.Add("precio", Type.GetType("System.Double"))
        datos.Columns.Add("factor", Type.GetType("System.Double"))
        datos.Columns.Add("material", Type.GetType("System.String"))

        validarDatos()
        grdConsumos.DataSource = datos
        diseñogrid()
    End Sub
    Private Sub diseñogrid()

        Try
            With grdConsumos.DisplayLayout.Bands(0)
                .Columns("Ok").Hidden = True
                .Columns("Renglon").Hidden = True
                .Columns("Activo").Hidden = True
                .Columns("Activo").Hidden = True

                .Columns("idMaterialNave").Hidden = True
                .Columns("ClasificacionDes").Hidden = True
                .Columns("idClasificacion").Hidden = True
                .Columns("UMC").Hidden = True
                .Columns("UMP").Hidden = True
                .Columns("idUMC").Hidden = True
                .Columns("idUMProd").Hidden = True
                .Columns("precio").Hidden = True
                .Columns("factor").Hidden = True
                .Columns("material").Header.Caption = " Nombre Material"
                .Columns("ComponenteDes").Header.Caption = " Nombre Componente"
                .Columns("ProveedorDes").Header.Caption = " Nombre Proveedor"

                .Columns("material").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("ProveedorDes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("ComponenteDes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Validación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

                .Columns(0).Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
                .Columns(0).Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns(0).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns(0).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns(0).AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .Columns(0).Width = 75

                .Columns(1).Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
                .Columns(1).Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns(1).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns(1).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns(1).AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .Columns(1).Width = 90
                .Columns(2).Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
                .Columns(2).Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns(2).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns(2).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns(2).AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .Columns(2).Width = 75

            End With
            grdConsumos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdConsumos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        Catch ex As Exception
        End Try

    End Sub
    Private Sub validarDatos()
        Dim d As New DataTable
        Dim obj As New ConsumosBU
        Me.Cursor = Cursors.WaitCursor

        For Each row As DataRow In datos.Rows
            row("Activo") = 1

            Try 'Bloqueado
                'If Not Convert.ToInt32(row(0)) = 1 And Not Convert.ToInt32(row(0)) = 0 Then
                'row("Validación") = " 1 si Bloquea 0 si no se Bloquea"
                'Else
                Try 'Explosionar
                    If Not Convert.ToInt32(row(0)) = 1 And Not Convert.ToInt32(row(0)) = 0 Then
                        row("Validación") = " 1 si Explosiona 0 si no se Explosiona"
                    Else
                        Try 'Lotear
                            If Not Convert.ToInt32(row(1)) = 1 And Not Convert.ToInt32(row(1)) = 0 Then
                                row("Validación") = " 1 si Lotea 0 si no se Lotea"
                            Else
                                Try
                                    'Validaciones en la base de datos
                                    d = obj.getComponente(row(2)) 'Datos para verificar componente
                                    If d.Rows.Count > 0 Then
                                        For Each row2 As DataRow In d.Rows
                                            row("ComponenteDes") = row2("comp_descripción")
                                        Next
                                        d = obj.getMaterialporSKU(row(3)) 'Datos para verificar material
                                        If d.Rows.Count > 0 Then
                                            d = obj.getProveedor(row(5)) 'Datos para verificar proveedor
                                            If d.Rows.Count > 0 Then
                                                For Each row2 As DataRow In d.Rows
                                                    row("ProveedorDes") = row2("prov_razonsocial")
                                                Next
                                                d = obj.validarMaterialComponente(row(3), row(2)) 'Datos para verificar componente material
                                                If d.Rows.Count > 0 Then
                                                    For Each row2 As DataRow In d.Rows
                                                        row("ClasificacionDes") = row2("clas_nombreclas")
                                                        row("idClasificacion") = row2("clas_idClasificacion")
                                                    Next

                                                    d = obj.validarAsignacionMaterial(row(3), idNave) 'Datos para verificar asignación del material a la nave
                                                    If d.Rows.Count > 0 Then
                                                        For Each row2 As DataRow In d.Rows
                                                            row("idMaterialNave") = row2("mn_materialNaveid")
                                                            row("material") = row2("mate_descripcion")
                                                        Next
                                                        d = obj.validarMaterialProveedor(row(5), row("idMaterialNave")) 'Datos para verificar que tenga precio con el proveedor especificado
                                                        If d.Rows.Count > 0 Then
                                                            For Each row2 As DataRow In d.Rows
                                                                row("UMC") = row2("prma_umproveedor")
                                                                row("UMP") = row2("prma_umproduccion")
                                                                row("idUMC") = row2("prma_idumproveedor")
                                                                row("idUMProd") = row2("prma_idumproduccion")
                                                                row("precio") = row2("prma_preciounitario")
                                                                row("factor") = row2("prma_equivalencia")
                                                            Next
                                                            row("Validación") = "CORRECTO"
                                                        Else
                                                            row("Validación") = "No existe precio del material con el proveedor especificado."
                                                        End If
                                                    Else
                                                        row("Validación") = "El Material no está asignado a la nave."
                                                    End If
                                                Else
                                                    row("Validación") = "Este componente no está asignado al material."
                                                End If
                                            Else
                                                row("Validación") = "El 'ID' del Proveedor no existe o no está activo."
                                            End If
                                        Else
                                            row("Validación") = "El 'SKU' del Material no existe o no está activo."
                                        End If
                                    Else
                                        row("Validación") = "El 'ID' del componente no existe o no está activo."
                                    End If
                                Catch ex As Exception
                                    row("Validación") = "Error."
                                End Try
                                ' fin de las validaciones a la base de datos
                            End If
                        Catch ex As Exception
                            row("Validación") = "1 si Lotea 0 si no se Lotea"
                        End Try
                    End If
                Catch ex As Exception
                    row("Validación") = " 1 si Explosiona 0 si no se Explosiona"
                End Try
                'End If
            Catch ex As Exception
                row("Validación") = " 1 si Bloquea 0 si no se Bloquea"
            End Try
        Next
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub grdConsumos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdConsumos.InitializeRow
        If e.Row.Cells.Exists("Validación") Then
            If e.Row.Cells("Validación").Value.ToString.Trim = "CORRECTO" Then
                e.Row.Cells("Validación").Appearance.ForeColor = Color.DarkGreen
            Else
                e.Row.Cells("Validación").Appearance.ForeColor = Color.Red
            End If
        End If
        Try
            e.Row.Cells("SKU").Value = e.Row.Cells("SKU").Value.ToString.ToUpper
            e.Row.Cells("Validación").Value = e.Row.Cells("Validación").Value.ToString.ToUpper
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        datos = grdConsumos.DataSource
        validarDatos()
        grdConsumos.DataSource = Nothing
        grdConsumos.DataSource = datos
        diseñogrid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        datos = grdConsumos.DataSource
        validarDatos()
        grdConsumos.DataSource = datos
        diseñogrid()


        Dim d As New DataTable
        consumos = New DataTable
        consumos.Columns.Add("Activo", Type.GetType("System.Boolean"))
        consumos.Columns.Add("Editado", Type.GetType("System.Boolean"))
        consumos.Columns.Add("Bloqueado", Type.GetType("System.Boolean"))
        consumos.Columns.Add("Explosionar", Type.GetType("System.Boolean"))
        consumos.Columns.Add("Lotear", Type.GetType("System.Boolean"))
        consumos.Columns.Add("idComponente", Type.GetType("System.Int32"))
        consumos.Columns.Add("Componente", Type.GetType("System.String"))
        consumos.Columns.Add("idClasificacion", Type.GetType("System.Int32"))
        consumos.Columns.Add("Clasificación", Type.GetType("System.String"))
        consumos.Columns.Add("IdMaterial", Type.GetType("System.Int32"))
        consumos.Columns.Add("SKU", Type.GetType("System.String"))
        consumos.Columns.Add("Material", Type.GetType("System.String"))
        consumos.Columns.Add("idConsumo", Type.GetType("System.Int32"))
        consumos.Columns.Add("Consumo", Type.GetType("System.Double"))
        consumos.Columns.Add("idUMC", Type.GetType("System.Int32"))
        consumos.Columns.Add("UMC", Type.GetType("System.String"))
        consumos.Columns.Add("idProveedor", Type.GetType("System.Int32"))
        consumos.Columns.Add("Proveedor", Type.GetType("System.String"))
        consumos.Columns.Add("Precio Compra", Type.GetType("System.Double"))
        consumos.Columns.Add("idUMProd", Type.GetType("System.Int32"))
        consumos.Columns.Add("UMP", Type.GetType("System.String"))
        consumos.Columns.Add("Factor", Type.GetType("System.Double"))
        consumos.Columns.Add("PrecioUM", Type.GetType("System.Double"))
        consumos.Columns.Add("Costo X Par", Type.GetType("System.Double"))
        consumos.Columns.Add("productoEstiloId", Type.GetType("System.Int32"))

        d = grdConsumos.DataSource

        For Each row As DataRow In d.Rows
            If Not row("Validación") = "CORRECTO" Then
                guardar = False
            End If
        Next
        Dim r As DataRow
        If guardar Then
            For Each row As DataRow In d.Rows
                If row("Validación") = "CORRECTO" Then
                    r = consumos.NewRow()
                    r("Activo") = 1
                    r("Editado") = 0
                    r("Bloqueado") = 0
                    r("Explosionar") = row("Explosionar")
                    r("Lotear") = row("Lotear")
                    r("idComponente") = row("Componente")
                    r("Componente") = row("ComponenteDes")
                    r("idClasificacion") = row("idClasificacion")
                    r("Clasificación") = row("ClasificacionDes")
                    r("IdMaterial") = row("idMaterialNave")
                    r("SKU") = row("SKU")
                    r("Material") = row("material")
                    r("idConsumo") = 0
                    r("Consumo") = row("Consumo")
                    r("idUMC") = row("idUMC")
                    r("UMC") = row("UMC")
                    r("idProveedor") = row("Proveedor")
                    r("Proveedor") = row("ProveedorDes")
                    r("Precio Compra") = row("precio")
                    r("idUMProd") = row("idUMProd")
                    r("UMP") = row("UMP")
                    r("Factor") = row("factor")
                    r("PrecioUM") = row("precio") / row("factor")
                    r("Costo X Par") = r("PrecioUM") * row("Consumo")
                    r("productoEstiloId") = 0
                    consumos.Rows.Add(r)
                End If
            Next
            Me.Close()
        Else
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "Solo se exportarán los consumos con validación 'correcto' ¿Desea continuar?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each row As DataRow In d.Rows
                    If row("Validación") = "CORRECTO" Then
                        r = consumos.NewRow()
                        r("Activo") = 1
                        r("Editado") = 0
                        r("Bloqueado") = row(0)
                        r("Explosionar") = row("Explosionar")
                        r("Lotear") = row("Lotear")
                        r("idComponente") = row("Componente")
                        r("Componente") = row("ComponenteDes")
                        r("idClasificacion") = row("idClasificacion")
                        r("Clasificación") = row("ClasificacionDes")
                        r("IdMaterial") = row("idMaterialNave")
                        r("SKU") = row("SKU")
                        r("Material") = row("material")
                        r("idConsumo") = 0
                        r("Consumo") = row("Consumo")
                        r("idUMC") = row("idUMC")
                        r("UMC") = row("UMC")
                        r("idProveedor") = row("Proveedor")
                        r("Proveedor") = row("ProveedorDes")
                        r("Precio Compra") = row("precio")
                        r("idUMProd") = row("idUMProd")
                        r("UMP") = row("UMP")
                        r("Factor") = row("factor")
                        r("PrecioUM") = row("precio") / row("factor")
                        r("Costo X Par") = r("PrecioUM") * row("Consumo")
                        r("productoEstiloId") = 0
                        consumos.Rows.Add(r)
                        guardar = True
                    End If
                Next
                Me.Close()
            End If
        End If

    End Sub
End Class