Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports Tools
Imports System.ComponentModel

Public Class DevolucionCliente_GenerarParesAGranel_AtadosEspeciales_Form
    Public ParesAtadosNormales As Integer = 0
    Public ParesAtadosEspeciales As Integer = 0
    Public TotalPares As Integer = 0

    Public FolioDevolucionId As Integer = 0
    Public FolioDevolucionDetalleId As Integer = 0
    Public IdTalla As Integer = 0
    Public ListaTallas As List(Of Entidades.TallasDevoluciones)
    Public dtTallasArticulo As New DataTable
    Dim dtParesAtadoEspecial As New DataTable

    Dim ListaParesPorTallaOriginal As New List(Of Entidades.TallasDevoluciones)
    Dim ListaParesPorTallaRestante As New List(Of Entidades.TallasDevoluciones)
    Dim DtTallas As New DataTable
    'Dim dtTallasArticulo As New DataTable

    Dim ObjBU As New Negocios.DevolucionCliente_IntegracionInventarioBU
    Dim InfoFolioDetalleId As New Entidades.FolioDevolucion_Detalle
    Public dtListadoAtadosEspeciales As New DataTable
    Public InfoAtados As New Entidades.InfoAtadosEspeciales
    Dim GuardadoExitoso As Boolean = False
    Public EsEdicion As Boolean = False
    Dim dtListadoAtadosEspecialesAux As New DataTable


    Private Sub DevolucionCliente_GenerarParesAGranel_AtadosEspeciales_Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        DtTallas = ObjBU.ConsultaTallasCorridas(IdTalla)
        CargarInformacion(FolioDevolucionDetalleId)
        CargarGridTallasDisponibles()
        grdListadoAtados.DataSource = InfoAtados.DtListadoAtadosEspeciales
        CrearColumnas()
        CargarInformacionGrids()

        lblAtadosNormales.Text = CDbl(ParesAtadosNormales).ToString("N0")
        ParesAtadosEspeciales = TotalPares - ParesAtadosNormales
        lblAtadosEspeciales.Text = CDbl(ParesAtadosEspeciales).ToString("N0")
        lblNumeroAtados.Text = CInt(ParesAtadosEspeciales / CInt(txtParesPorAtados.Text)).ToString()

        If CInt(lblAtadosEspeciales.Text) <= CInt(txtParesPorAtados.Text) Then
            CargarAtadoEspecial()
        End If


        lblNumAtadosEspeciales.Text = CDbl(dtListadoAtadosEspeciales.Rows.Count()).ToString("N0")
        lblParesAtadosEspeciales.Text = CDbl(dtListadoAtadosEspeciales.AsEnumerable().Sum(Function(x) x.Item("Total"))).ToString("N0")



    End Sub

    Public Sub CargarAtadoEspecial()

        For Each Fila As Entidades.TallasDevoluciones In ListaTallas
            dtParesAtadoEspecial.Rows(0).Item(Fila.Talla) = dtTallasArticulo.Rows(1).Item(Fila.Talla)
        Next

        grdAtadosEspeciales.DataSource = dtParesAtadoEspecial

    End Sub

    Public Sub CargarInformacionGrids()
        grdAtadosEspeciales.DataSource = dtParesAtadoEspecial
        grdListadoAtados.DataSource = dtListadoAtadosEspeciales

        viewAtadosEspeciales.Columns.ColumnByFieldName("Atado").OptionsColumn.AllowEdit = False
        viewAtadosEspeciales.Columns.ColumnByFieldName("Total").OptionsColumn.AllowEdit = False

        For Each fila As DataRow In DtTallas.Rows
            If ListaTallas.Exists(Function(x) x.Talla = fila.Item("Talla")) = True Then
                viewAtadosEspeciales.Columns.ColumnByFieldName(fila.Item("Talla")).OptionsColumn.AllowEdit = True
            Else
                viewAtadosEspeciales.Columns.ColumnByFieldName(fila.Item("Talla")).OptionsColumn.AllowEdit = False
            End If

        Next

    End Sub

    Public Sub CrearColumnas()

        dtParesAtadoEspecial.Columns.Add("Atado")
        For Each Columna As DataRow In DtTallas.Rows
            dtParesAtadoEspecial.Columns.Add(Columna.Item("Talla"), GetType(String))
        Next
        dtParesAtadoEspecial.Columns.Add("Total")
        dtParesAtadoEspecial.Rows.Add("1")

        If EsEdicion = False Then
            dtListadoAtadosEspeciales = dtParesAtadoEspecial.Clone()
        End If


    End Sub

    Public Sub CrearNuevaFilaAtadosEspeciales()

        If dtParesAtadoEspecial.Rows.Count > 0 Then
            dtParesAtadoEspecial.Rows(0).Delete()
            dtParesAtadoEspecial.Rows.Add((dtListadoAtadosEspeciales.Rows.Count + 1).ToString())

            grdAtadosEspeciales.RefreshDataSource()
        End If

    End Sub

    Public Sub CargarGridTallasDisponibles()
        Dim Talla_1 As New Entidades.TallasDevoluciones
        Dim Talla_2 As New Entidades.TallasDevoluciones
        Dim TotalPares As Integer = 0


        ' DtTallas = ObjBU.ConsultaTallasCorridas(IdTalla)

        'Crear las Columnas del DataTable
        dtTallasArticulo.Columns.Add("Concepto")

        For Each Columna As DataRow In DtTallas.Rows
            dtTallasArticulo.Columns.Add(Columna.Item("Talla"), GetType(String))
        Next
        dtTallasArticulo.Columns.Add("Total")

        'Crear la primera Fila
        dtTallasArticulo.Rows.Add("Original")

        For Each Fila As Entidades.TallasDevoluciones In ListaTallas
            dtTallasArticulo.Rows(0).Item(Fila.Talla) = Fila.Cantidad
            Talla_1 = New Entidades.TallasDevoluciones
            Talla_2 = New Entidades.TallasDevoluciones

            Talla_1.Talla = Fila.Talla
            Talla_1.Cantidad = Fila.Cantidad

            Talla_2.Talla = Fila.Talla
            Talla_2.Cantidad = Fila.Cantidad

            ListaParesPorTallaOriginal.Add(Talla_1)
            ListaParesPorTallaRestante.Add(Talla_2)

            TotalPares += Fila.Cantidad
        Next

        dtTallasArticulo.Rows(0).Item("Total") = TotalPares

        'Crear la Segunda Fila
        TotalPares = 0

        dtTallasArticulo.Rows.Add("Restante")


        For Each Fila As Entidades.TallasDevoluciones In ListaTallas
            If EsEdicion = True Then
                dtTallasArticulo.Rows(1).Item(Fila.Talla) = 0
                TotalPares = 0
            Else
                dtTallasArticulo.Rows(1).Item(Fila.Talla) = Fila.Cantidad
                TotalPares += Fila.Cantidad
            End If
        Next

        dtTallasArticulo.Rows(1).Item("Total") = TotalPares

        grdDocenasEspeciales.DataSource = dtTallasArticulo
        grdVDocenasEspeciales.BestFitColumns()
    End Sub

    Public Sub CargarInformacion(ByVal FolioDetalleId As Integer)
        InfoFolioDetalleId = ObjBU.ConsultaInformacionDetalle(FolioDetalleId)
        lblFolioDevolucion.Text = InfoFolioDetalleId.FolioDevolucion.ToString()
        lblCliente.Text = InfoFolioDetalleId.Cliente
        lblDescripcionArticulo.Text = InfoFolioDetalleId.Articulo
        lblTotalPares.Text = InfoFolioDetalleId.CantidadPares.ToString()
    End Sub

    Private Sub btnAgregarAtado_Click(sender As Object, e As EventArgs) Handles btnAgregarAtado.Click
        Dim Row As DataRowView = CType(viewAtadosEspeciales.GetRow(0), DataRowView)
        Dim ContadorAtados As Integer = 0
        Dim Total As Integer = 0
        Dim ParesPorAtado As Integer = 0

        If IsNumeric(txtParesPorAtados.Text) = False Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha capturado los pares por atado.")
            Return
        Else
            ParesPorAtado = txtParesPorAtados.Text
        End If

        If ParesPorAtado = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Los pares por Atado debe de ser mayor a 0.")
            Return
        End If

        ContadorAtados = dtListadoAtadosEspeciales.Rows.Count + 1

        For Each Fila As DataRow In DtTallas.Rows
            If IsNumeric(Row.Item(Fila.Item("Talla"))) = True Then
                Total += CInt(Row.Item(Fila.Item("Talla")))
            End If
        Next

        If dtTallasArticulo.Rows(1).Item("Total") = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay pares para crear el atado.")
        Else
            If Total = ParesPorAtado Then
                Total = 0
                dtListadoAtadosEspeciales.Rows.Add(ContadorAtados.ToString())
                For Each Fila As DataRow In DtTallas.Rows
                    dtListadoAtadosEspeciales.Rows(ContadorAtados - 1).Item(Fila.Item("Talla")) = Row.Item(Fila.Item("Talla"))
                    If IsNumeric(Row.Item(Fila.Item("Talla"))) = True Then
                        Total += CInt(Row.Item(Fila.Item("Talla")))
                        dtTallasArticulo.Rows(1).Item(Fila.Item("Talla")) = (CInt(dtTallasArticulo.Rows(1).Item(Fila.Item("Talla"))) - CInt(Row.Item(Fila.Item("Talla")))).ToString()
                        dtTallasArticulo.Rows(1).Item("Total") = (CInt(dtTallasArticulo.Rows(1).Item("Total")) - CInt(Row.Item(Fila.Item("Talla")))).ToString()
                    End If
                Next


                dtListadoAtadosEspeciales.Rows(ContadorAtados - 1).Item("Total") = Total.ToString()
                grdListadoAtados.RefreshDataSource()
                grdDocenasEspeciales.RefreshDataSource()
                CrearNuevaFilaAtadosEspeciales()
            ElseIf dtTallasArticulo.Rows(1).Item("Total") < ParesPorAtado And dtTallasArticulo.Rows(1).Item("Total") > 0 And Total > 0 Then
                Total = 0
                dtListadoAtadosEspeciales.Rows.Add(ContadorAtados.ToString())
                For Each Fila As DataRow In DtTallas.Rows
                    dtListadoAtadosEspeciales.Rows(ContadorAtados - 1).Item(Fila.Item("Talla")) = Row.Item(Fila.Item("Talla"))
                    If IsNumeric(Row.Item(Fila.Item("Talla"))) = True Then
                        Total += CInt(Row.Item(Fila.Item("Talla")))
                        dtTallasArticulo.Rows(1).Item(Fila.Item("Talla")) = (CInt(dtTallasArticulo.Rows(1).Item(Fila.Item("Talla"))) - CInt(Row.Item(Fila.Item("Talla")))).ToString()
                        dtTallasArticulo.Rows(1).Item("Total") = (CInt(dtTallasArticulo.Rows(1).Item("Total")) - CInt(Row.Item(Fila.Item("Talla")))).ToString()
                    End If
                Next

                dtListadoAtadosEspeciales.Rows(ContadorAtados - 1).Item("Total") = Total.ToString()
                grdListadoAtados.RefreshDataSource()
                grdDocenasEspeciales.RefreshDataSource()
                CrearNuevaFilaAtadosEspeciales()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha completado los pares por atado.")
            End If

        End If


        lblNumAtadosEspeciales.Text = CDbl(dtListadoAtadosEspeciales.Rows.Count()).ToString("N0")
        lblParesAtadosEspeciales.Text = CDbl(dtListadoAtadosEspeciales.AsEnumerable().Sum(Function(x) x.Item("Total"))).ToString("N0")

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnEliminarAtadoEspecial_Click(sender As Object, e As EventArgs) Handles btnEliminarAtadoEspecial.Click

        Dim Row As DataRowView = CType(viewListadoAtadosEspeciales.GetRow(viewListadoAtadosEspeciales.FocusedRowHandle), DataRowView)
        Dim NumeroAtado As String = String.Empty
        Dim FilaAtado As DataRow
        Dim ContadorAtados As Integer = 1

        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas eliminar el atado seleccionado?"

        Try
            If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                NumeroAtado = Row.Item("Atado")
                FilaAtado = dtListadoAtadosEspeciales.AsEnumerable().Where(Function(x) x.Item("Atado") = NumeroAtado).FirstOrDefault()

                'Sumar Los pares eliminados al encabezado
                For Each Fila As DataRow In DtTallas.Rows
                    If IsNumeric(Row.Item(Fila.Item("Talla"))) = True Then
                        dtTallasArticulo.Rows(1).Item(Fila.Item("Talla")) = (CInt(FilaAtado.Item(Fila.Item("Talla"))) + CInt(dtTallasArticulo.Rows(1).Item(Fila.Item("Talla")))).ToString()
                        dtTallasArticulo.Rows(1).Item("Total") = (CInt(dtTallasArticulo.Rows(1).Item("Total")) + CInt(FilaAtado.Item(Fila.Item("Talla")))).ToString()

                    End If
                Next

                dtListadoAtadosEspeciales.Rows.Remove(FilaAtado)

                'ReAsignar el numero de Atado
                For Each Fila As DataRow In dtListadoAtadosEspeciales.Rows
                    Fila.Item("Atado") = ContadorAtados.ToString
                    ContadorAtados += 1
                Next

                grdDocenasEspeciales.RefreshDataSource()
                grdListadoAtados.RefreshDataSource()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub viewAtadosEspeciales_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles viewAtadosEspeciales.ValidatingEditor
        Dim ParesDisponibles As Integer = 0
        Dim ParesPendientes As Integer = 0
        Dim ParesPorAtado As Integer = 0
        Dim ParesAsignados As Integer = 0
        Dim esValido As Boolean = True

        Dim view As ColumnView = sender
        Dim column As GridColumn = If(TryCast(e, EditFormValidateEditorEventArgs)?.Column, view.FocusedColumn)

        If IsNumeric(txtParesPorAtados.Text) = True Then
            ParesPorAtado = CInt(txtParesPorAtados.Text)
        Else
            e.Valid = False
            e.ErrorText = "No se ha capturado los pares por Atado."
            esValido = False
        End If

        If IsDBNull(e.Value) OrElse e.Value = String.Empty Then
            esValido = False
        End If

        For Each fila As DataRow In DtTallas.Rows
            If IsNumeric(viewAtadosEspeciales.GetRowCellValue(0, fila.Item("Talla"))) = True Then

                If column.FieldName = fila.Item("Talla") Then
                    'ParesAsignados += e.Value
                    If IsNumeric(e.Value) = True Then
                        ParesAsignados += e.Value
                    End If
                Else
                    ParesAsignados += CInt(viewAtadosEspeciales.GetRowCellValue(0, fila.Item("Talla")))
                End If

            Else
                If column.FieldName = fila.Item("Talla") Then
                    If IsNumeric(e.Value) = True Then
                        ParesAsignados += e.Value
                    End If
                End If

            End If

        Next

        If esValido = True Then
            If viewAtadosEspeciales.FocusedRowHandle >= 0 Then

                If IsNumeric(e.Value) = False Then
                    e.ErrorText = "El valor ingresado no es un número."
                    e.Valid = False
                Else
                    ParesDisponibles = dtTallasArticulo.Rows(1).Item(column.FieldName)
                    ParesPendientes = e.Value
                    If ParesPendientes > ParesDisponibles Then
                        e.ErrorText = "No puede asignar mas pares de los disponibles."
                        e.Valid = False
                    Else

                        If ParesAsignados > ParesPorAtado Then
                            e.ErrorText = "Ya se ha superado los pares por Atado."
                            e.Valid = False
                        End If
                    End If

                End If

            End If
        End If

        viewAtadosEspeciales.SetRowCellValue(0, "Total", ParesAsignados)


    End Sub


    Private Sub DevolucionCliente_GenerarParesAGranel_AtadosEspeciales_Form_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim formaConfirmacion As New ConfirmarForm

        If GuardadoExitoso = False Then
            formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
            formaConfirmacion.mensaje = "¿Estas seguro que deseas salir?"

            If formaConfirmacion.ShowDialog() <> Windows.Forms.DialogResult.OK Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub btnGenerarAtadosE_Click(sender As Object, e As EventArgs) Handles btnGenerarAtadosE.Click

        'Validar que todos los pares esten en atados
        If CInt(dtTallasArticulo.Rows(1).Item("Total")) = 0 Then
            InfoAtados.NumeroAtados = dtListadoAtadosEspeciales.Rows.Count
            InfoAtados.NumeroPares = ParesAtadosEspeciales
            InfoAtados.FolioDetalle = FolioDevolucionDetalleId
            InfoAtados.DtListadoAtadosEspeciales = dtListadoAtadosEspeciales
            GuardadoExitoso = True
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Todavia hay pares pendientes de asignar un atado.")
        End If

    End Sub

    Private Sub txtParesPorAtados_TextChanged(sender As Object, e As EventArgs) Handles txtParesPorAtados.TextChanged
        If IsNumeric(txtParesPorAtados.Text) = True Then
            If CInt(txtParesPorAtados.Text) = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "La cantidad de pares por atado debe ser mayor a 0.")
            Else
                CrearNuevaFilaAtadosEspeciales()
                lblNumeroAtados.Text = CInt(ParesAtadosEspeciales / CInt(txtParesPorAtados.Text)).ToString()
                If lblAtadosEspeciales.Text <> "" Then
                    If CInt(lblAtadosEspeciales.Text) <= CInt(txtParesPorAtados.Text) Then
                        CargarAtadoEspecial()
                    End If
                End If

            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "El valor capturado no es un número.")
        End If

    End Sub


End Class