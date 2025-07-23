Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListMarcasProductoForm
    Dim TablaMarcas As DataTable

    Public Sub llenarTablaMarcas()
        Dim MarcasDatosTabla As New Programacion.Negocios.MarcasBU
        Dim Activo As Boolean = True
        If (rdoInactivo.Checked) Then
            Activo = False
        ElseIf (rdoActivo.Checked) Then
            Activo = True
        End If
        grdListaMarcas.DataSource = Nothing
        TablaMarcas = New DataTable
        TablaMarcas = MarcasDatosTabla.TablaMarcas(Activo)

        grdListaMarcas.DataSource = TablaMarcas
        'marc_marcaid, marc_codigo, marc_descripcion, marc_activo, marc_codigosicy, marc_esCliente
        With grdListaMarcas.DisplayLayout.Bands(0)
            .Columns("marc_marcaid").Hidden = True
            .Columns("marc_activo").Hidden = True
            .Columns("marc_marcaid").Hidden = True
            .Columns("marc_esCliente").Hidden = True
            .Columns("marc_codigo").Header.Caption = "Código"
            .Columns("marc_descripcion").Header.Caption = "Nombre"
            .Columns("marc_codigosicy").Header.Caption = "SICY"
            .Columns("marc_esCliente").Header.Caption = "Cliente"
            .Columns("marc_codigo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("marc_codigo").CellActivation = Activation.NoEdit
            .Columns("marc_descripcion").CellActivation = Activation.NoEdit
            .Columns("marc_codigosicy").CellActivation = Activation.NoEdit
            .Columns("marc_esCliente").CellActivation = Activation.NoEdit

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaMarcas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaMarcas.DisplayLayout.Bands(0).Columns("marc_codigo").Width = 30
        grdListaMarcas.DisplayLayout.Bands(0).Columns("marc_codigosicy").Width = 30

        Me.grdListaMarcas.DisplayLayout.Bands(0).Columns.Add("selectCliente", "")
        Dim colckbCr As UltraGridColumn = grdListaMarcas.DisplayLayout.Bands(0).Columns("selectCliente")
        colckbCr.Width = 30
        colckbCr.Header.Caption = "Clientes"
        colckbCr.Style = ColumnStyle.Image

        'grdListaMarcas.Columns(1).ReadOnly = True
        'grdListaMarcas.Columns(2).ReadOnly = True
        'grdListaMarcas.Columns(4).ReadOnly = True
        'Me.grdListaMarcas.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        'Me.grdListaMarcas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

    End Sub

    ' ''valida que existan códigos para asignar
    Public Function ValidarExistencia() As Boolean
        Dim MarcaNegocios As New Programacion.Negocios.MarcasBU
        Dim dtTabla As DataTable = MarcaNegocios.VerMarcas
        Dim ValidacionExistePrimero As Int32 = dtTabla.Rows.Count
        Dim dtidMarca As DataTable = New DataTable
        dtidMarca = MarcaNegocios.SeleccionarMaximoId
        Dim codigoNuevo As String = String.Empty
        Dim IdMaximo As Int32 = 0
        Dim IdNuevo As Int32 = 0

        If (ValidacionExistePrimero = 0) Then
            'AltaMarcaForm.txtCodigo.Text = "1"
            Return True
        ElseIf (ValidacionExistePrimero >= 1) Then
            'IdMaximo = Convert.ToInt32(dtidMarca.Rows(0)("MaximoID").ToString)
            Dim dtCodigosDisponibles As DataTable
            dtCodigosDisponibles = New DataTable
            dtCodigosDisponibles = MarcaNegocios.VerCodigosDisponibles()
            If (ValidacionExistePrimero >= 36) Then
                If (dtCodigosDisponibles.Rows.Count = 0) Then
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Public Sub EnviarEditarMarca()
        Try
            Dim EntidadMarca As New Entidades.Marcas
            'Dim MarcaNegocio As New Programacion.Negocios.Class1
            Dim Fila As Int32 = 0
            Fila = grdListaMarcas.ActiveRow.Index
            If (grdListaMarcas.Rows(Fila).Cells(0).Value().ToString = "1") Then
                Dim mensaje As New AdvertenciaForm
                mensaje.mensaje = "El registro ANDREA no puede ser modificado."
                mensaje.ShowDialog()
            Else
                EntidadMarca.PMarcaId = grdListaMarcas.Rows(Fila).Cells(0).Value.ToString
                EntidadMarca.PCodigo = grdListaMarcas.Rows(Fila).Cells(1).Value.ToString
                EntidadMarca.PDescripcion = grdListaMarcas.Rows(Fila).Cells(2).Value.ToString
                EntidadMarca.PActivo = grdListaMarcas.Rows(Fila).Cells(3).Value.ToString
                EntidadMarca.PSicyCodigo = grdListaMarcas.Rows(Fila).Cells(4).Value.ToString
                EntidadMarca.PClienteMarca = Convert.ToBoolean(grdListaMarcas.Rows(Fila).Cells(5).Value.ToString)
                Dim edMarca As New EditarMarcaForm
                edMarca.LlenarDatosMarcaModificar(EntidadMarca)
                edMarca.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox("Debe seleccionar un registro.")
        End Try
    End Sub


    Private Sub ListMarcasProductoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        ' ''llenarTablaMarcas()
        rdoActivo.Checked = True
        grdListaMarcas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaMarcas.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaMarcas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaMarcas.Rows(0).Selected = True
        ''MessageBox.Show(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        ''MessageBox.Show(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
    End Sub


    Private Sub btnAltaMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaMarca.Click
        If (ValidarExistencia() = True) Then
            Dim almar As New AltaMarcaForm
            almar.ShowDialog()
            llenarTablaMarcas()

        ElseIf (ValidarExistencia() = False) Then
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "No existen códigos para asignar a la marca."
            mensaje.ShowDialog()
        End If

    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        llenarTablaMarcas()

    End Sub

    Private Sub btnOcultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pnlParametros.Height = 98
    End Sub

    Private Sub btnRestaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pnlParametros.Height = 40
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        EnviarEditarMarca()
        llenarTablaMarcas()
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        llenarTablaMarcas()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        llenarTablaMarcas()
    End Sub

    Private Sub grdListaMarcas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaMarcas.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdListaMarcas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdListaMarcas.InitializeRow
        If e.Row.Cells.Exists("selectCliente") Then
            If CBool(grdListaMarcas.Rows(e.Row.Index).Cells("marc_esCliente").Value) = True Then
                e.Row.Cells("selectCliente").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.ClienteProg
            End If
        End If
    End Sub

    Private Sub grdListaMarcas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaMarcas.InitializeLayout
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next
    End Sub

    Private Sub grdListaMarcas_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdListaMarcas.DoubleClickCell
        If e.Cell.Column.Key = "selectCliente" And e.Cell.Row.Index <> grdListaMarcas.Rows.FilterRow.Index And CBool(grdListaMarcas.Rows(e.Cell.Row.Index).Cells("marc_esCliente").Value) = True Then
            Dim fila As Int32 = e.Cell.Row.Index
            Dim objCliente As New ListaConsultaClientesForm
            objCliente.idMarca = grdListaMarcas.Rows(fila).Cells("marc_marcaid").Value.ToString
            objCliente.nombreMarca = grdListaMarcas.Rows(fila).Cells("marc_descripcion").Value.ToString
            objCliente.accionFormulario = "consultaCMarcas"
            objCliente.ShowDialog()
        End If
    End Sub
End Class