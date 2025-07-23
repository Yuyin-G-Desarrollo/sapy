Imports System.Globalization
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class AdministradorExcepcionFacturacionForm

#Region "Variables Globales"

    Private inicio As Boolean = True
    Private Datos As New DataTable
    Private listaOriginal As List(Of String)
    Private listaDeseleccion As List(Of String)
    Private listaSeleccion As List(Of String)
    Private listaSinRegistro As List(Of String)
    Private listaNuevos As List(Of String)

#End Region

    Private Sub ListadoParametrosReportesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarVista(gridClientes)
    End Sub

#Region "Panel Parametros"

    Private Sub ChboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
        If chboxMarcarTodo.Checked Then
            For Each row In gridClientes.Rows.GetFilteredInNonGroupByRows
                If row.Hidden = False Then

                    If Not listaOriginal.Contains(row.Cells("Parametro").Value) Then
                        listaSeleccion.Add(row.Cells("Parametro").Value)
                    End If

                    If listaDeseleccion.Contains(row.Cells("Parametro").Value) AndAlso listaOriginal.Contains(row.Cells("Parametro").Value) Then
                        listaDeseleccion.Remove(row.Cells("Parametro").Value)
                    End If

                    row.Cells(" ").Value = True
                End If
            Next
        Else
            For Each row As UltraGridRow In gridClientes.Rows.GetFilteredInNonGroupByRows

                If listaOriginal.Contains(row.Cells("Parametro").Value) Then
                    listaDeseleccion.Add(row.Cells("Parametro").Value)
                End If

                If listaSeleccion.Contains(row.Cells("Parametro").Value) Then
                    listaSeleccion.Remove(row.Cells("Parametro").Value)
                End If

                row.Cells(" ").Value = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In gridClientes.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub RdbActivos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbActivos.CheckedChanged
        If rdbActivos.Checked Then
            SeleccionarTipoFiltro()
        End If
    End Sub

    Private Sub RdbInactivos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbInactivos.CheckedChanged
        If rdbInactivos.Checked Then
            SeleccionarTipoFiltro()
        End If
    End Sub

    Private Sub RdbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTodos.CheckedChanged
        If rdbTodos.Checked Then
            SeleccionarTipoFiltro()
        End If
    End Sub

#End Region

#Region "Contenido"

    Private Sub GridListadoParametros_Click(sender As Object, e As EventArgs) Handles gridClientes.Click
        If Not Me.gridClientes.ActiveRow.IsDataRow Then Return

        If IsNothing(gridClientes.ActiveRow) Then Return

        If gridClientes.ActiveRow.Cells(" ").Value Then

            If listaOriginal.Contains(gridClientes.ActiveRow.Cells("Parametro").Value) Then
                listaDeseleccion.Add(gridClientes.ActiveRow.Cells("Parametro").Value)
            End If

            If listaSeleccion.Contains(gridClientes.ActiveRow.Cells("Parametro").Value) Then
                listaSeleccion.Remove(gridClientes.ActiveRow.Cells("Parametro").Value)
            End If

            If listaSinRegistro.Contains(gridClientes.ActiveRow.Cells("Parametro").Value) Then
                listaNuevos.Remove(gridClientes.ActiveRow.Cells("Parametro").Value)
            End If

            gridClientes.ActiveRow.Cells(" ").Value = False
        Else
            If Not listaOriginal.Contains(gridClientes.ActiveRow.Cells("Parametro").Value) AndAlso Not listaSinRegistro.Contains(gridClientes.ActiveRow.Cells("Parametro").Value) Then
                listaSeleccion.Add(gridClientes.ActiveRow.Cells("Parametro").Value)
            End If

            If Not listaOriginal.Contains(gridClientes.ActiveRow.Cells("Parametro").Value) AndAlso listaSinRegistro.Contains(gridClientes.ActiveRow.Cells("Parametro").Value) Then
                listaNuevos.Add(gridClientes.ActiveRow.Cells("Parametro").Value)
            End If

            If listaDeseleccion.Contains(gridClientes.ActiveRow.Cells("Parametro").Value) AndAlso listaOriginal.Contains(gridClientes.ActiveRow.Cells("Parametro").Value) Then
                listaDeseleccion.Remove(gridClientes.ActiveRow.Cells("Parametro").Value)
            End If

            gridClientes.ActiveRow.Cells(" ").Value = True
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In gridClientes.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub GridListadoParametros_AfterRowActivate(sender As Object, e As EventArgs) Handles gridClientes.AfterRowActivate
        gridClientes.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridClientes.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

#End Region

#Region "Panel Pie"

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Datos = New DataTable
        If gridClientes.Rows.Count = 0 Then Return

        Dim grid As DataTable = gridClientes.DataSource

        Datos.Columns.Add("ID")
        Datos.Columns.Add("Nombre")
        Datos.Columns.Add("Motivo")
        Datos.Columns.Add("Accion")
        Datos.Columns.Add("Solicita")

        For Each row As UltraGridRow In gridClientes.Rows

            If listaSeleccion.Contains(row.Cells("Parametro").Value) Then
                Dim fila As DataRow = Datos.NewRow

                fila(0) = row.Cells(0).Value
                fila(1) = row.Cells(2).Value
                fila(2) = ""
                fila(3) = "HABILITAR EXCEPCIÓN"

                Datos.Rows.Add(fila)
            End If

            If listaDeseleccion.Contains(row.Cells("Parametro").Value) Then
                Dim fila As DataRow = Datos.NewRow

                fila(0) = row.Cells(0).Value
                fila(1) = row.Cells(2).Value
                fila(2) = ""
                fila(3) = "DESHABILITAR EXCEPCIÓN"

                Datos.Rows.Add(fila)
            End If

            If listaNuevos.Contains(row.Cells("Parametro").Value) Then
                Dim fila As DataRow = Datos.NewRow

                fila(0) = row.Cells(0).Value
                fila(1) = row.Cells(2).Value
                fila(2) = ""
                fila(3) = "AGREGAR EXCEPCIÓN"

                Datos.Rows.Add(fila)
            End If
        Next

        If listaSeleccion.Count > 0 Or listaNuevos.Count > 0 Then
            Dim motivo = New MotivoExcepcionForm With {
                .listaSeleccion = listaSeleccion,
                .listaDeseleccion = listaDeseleccion,
                .listaNuevos = listaNuevos,
                .Datos = Datos
            }
            motivo.ShowDialog(Me)

            If motivo.OK Then
                Controles.Mensajes_Y_Alertas("EXITO", "Registro correcto.")
                'Else
                '    Controles.Mensajes_Y_Alertas("INFORMACION", "No se pudo hacer el registro.")
            End If
        ElseIf listaDeseleccion.Count > 0 Then
            Dim alerta = New MensajeConfirmarExcepcionForm With {
                .listaSeleccion = listaSeleccion,
                .listaDeseleccion = listaDeseleccion,
                .listaNuevos = listaNuevos,
                .Alerta = True,
                .Datos = Datos
            }
            alerta.ShowDialog(Me)
            If alerta.OK Then
                Controles.Mensajes_Y_Alertas("EXITO", "Registro correcto.")
                'Else
                '    Controles.Mensajes_Y_Alertas("INFORMACION", "No se pudo hacer el registro.")
            End If
        Else
            Controles.Mensajes_Y_Alertas("INFORMACION", "No hay nuevos datos a modificar.")
        End If
        inicio = True
        InicializarVista(gridClientes)
        rdbTodos.Checked = True
        chboxMarcarTodo.Checked = False
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub InicializarVista(grid As UltraGrid)
        Dim totalSeleccionados As Integer = 0
        listaDeseleccion = New List(Of String)
        listaSeleccion = New List(Of String)
        listaSinRegistro = New List(Of String)
        listaNuevos = New List(Of String)
        If inicio Then
            listaOriginal = New List(Of String)
        End If
        grid.DataSource = Nothing
        Dim objBU As New Negocios.AdministradorExcepcionFacturacionBU

        Try
            Dim Tabla_ListadoParametros As DataTable
            Dim Tabla_ListadoSinRegistro As DataTable

            Tabla_ListadoParametros = objBU.ListadoClientes()
            Tabla_ListadoSinRegistro = objBU.ListadoClientesSinRegistro()

            grid.DataSource = Tabla_ListadoParametros

            For Each row As DataRow In Tabla_ListadoSinRegistro.Rows
                listaSinRegistro.Add(row.Item(0))
            Next

            For Each row As UltraGridRow In grid.Rows
                If row.Cells("Activo").Value = True Or row.Cells("Activo").Value = 1 Then
                    row.Cells(" ").Value = True
                    listaOriginal.Add(row.Cells("Parametro").Value)
                End If
            Next

            For Each col In grid.DisplayLayout.Bands(0).Columns

                If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                    col.Style = ColumnStyle.Integer
                    col.CellAppearance.TextHAlign = HAlign.Right

                End If

                If col.DataType.Name.ToString.Equals("Decimal") Then

                    col.Style = ColumnStyle.DoublePositive
                    col.CellAppearance.TextHAlign = HAlign.Right

                End If

                If col.DataType.Name.ToString.Equals("String") Then

                    If col.Header.Caption.Equals("TELÉFONO") Then
                        col.MaskInput = "+## (###) ###-####"
                        col.MaskDisplayMode = UltraWinMaskedEdit.MaskMode.IncludeBoth
                        col.CellAppearance.TextHAlign = HAlign.Right
                    ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                        col.MaskInput = "ext: 9999"
                        col.MaskDisplayMode = UltraWinMaskedEdit.MaskMode.IncludeBoth
                        col.CellAppearance.TextHAlign = HAlign.Right
                    Else
                        col.CellAppearance.TextHAlign = HAlign.Left
                    End If

                End If

            Next

            With grid.DisplayLayout
                .Bands(0).Columns(0).Hidden = True
                .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
                .AutoFitStyle = AutoFitStyle.ResizeAllColumns
                .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
                .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
                .Override.RowSelectorWidth = 35
                .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
                .Override.CellClickAction = CellClickAction.RowSelect
                .Override.AllowRowFiltering = DefaultableBoolean.True
                .Override.AllowAddNew = AllowAddNew.No
            End With

            For Each col As UltraGridColumn In grid.DisplayLayout.Bands(0).Columns
                If col.Header.Caption = "Activo" Then
                    col.Hidden = True
                End If

                If col.Header.Caption = " " Then
                    col.Width = 35
                End If
            Next

            For Each row As UltraGridRow In gridClientes.Rows
                If row.Cells(" ").Value = True Then
                    totalSeleccionados += 1
                End If
            Next

            lblNumFiltrados.Text = totalSeleccionados.ToString("N0")
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        End Try

    End Sub

    Private Sub SeleccionarTipoFiltro()
        If inicio Then
            listaOriginal = New List(Of String)
            inicio = False
        End If
        Dim totalSeleccionados As Integer = 0

        For Each row As UltraGridRow In gridClientes.Rows.Where(Function(x) x.Cells(" ").Value = True)
            row.Cells(" ").Value = False
        Next
        lblNumFiltrados.Text = "0"
        If rdbActivos.Checked Then
            For Each Fila As UltraGridRow In gridClientes.Rows
                If Fila.Cells("Activo").Value = False Or Fila.Cells("Activo").Value = 0 Then
                    Fila.Hidden = True
                Else
                    Fila.Hidden = False
                    Fila.Cells(" ").Value = True
                End If
            Next
        ElseIf rdbActivos.Checked = False And rdbInactivos.Checked = True Then
            For Each Fila As UltraGridRow In gridClientes.Rows
                If Fila.Cells("Activo").Value = True Or Fila.Cells("Activo").Value = 1 Then
                    Fila.Hidden = True
                    Fila.Cells(" ").Value = False
                Else
                    Fila.Hidden = False
                End If
            Next
        ElseIf rdbTodos.Checked = True And rdbActivos.Checked = False Then
            For Each Fila As UltraGridRow In gridClientes.Rows
                Fila.Hidden = False
                If Fila.Cells("Activo").Value = True Or Fila.Cells("Activo").Value = 1 Then
                    Fila.Cells(" ").Value = True
                Else
                    Fila.Cells(" ").Value = False
                End If
            Next
        End If
        chboxMarcarTodo.Checked = False

        For Each item In listaOriginal
            For Each row As UltraGridRow In gridClientes.Rows
                If item = row.Cells(0).Text And row.Hidden = False Then
                    row.Cells(" ").Value = True
                    totalSeleccionados += 1
                End If
            Next
        Next

        lblNumFiltrados.Text = totalSeleccionados.ToString("N0")

    End Sub

#End Region

End Class