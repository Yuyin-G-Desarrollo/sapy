Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaConsultaClientesForm
    Public accionFormulario As String
    Public idMarca As Int32
    Public idColeccion As Int32
    Public nombreMarca As String
    Public idModelo As Int32

    Dim todosClientes As Boolean
    Dim idClienteList As Int32
    Dim nombreClienteList As String
    Dim descripcionesModelo As New DataTable

    Public Property pIdClienteList As Int32
        Get
            Return idClienteList
        End Get
        Set(value As Int32)
            idClienteList = value
        End Set
    End Property

    Public Property pNombreCliente As String
        Get
            Return nombreClienteList
        End Get
        Set(value As String)
            nombreClienteList = value
        End Set
    End Property

    Private Sub ListaConsultaClientesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarListaClientes()
        todosClientes = False
        If grdClientes.Rows.Count > 0 Then
            grdClientes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdClientes.DisplayLayout.Override.RowSelectorWidth = 35
            grdClientes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        End If
    End Sub

    Public Sub llenarListaClientes()
        If accionFormulario = "consultaCMarcas" Then
            llenarTablaClienteMostrarMarca()
        ElseIf accionFormulario = "consultaCColeccion" Then
            llenarTablaMostrarTodosLosCLientes()
        ElseIf accionFormulario = "descripcionEspecialClienteEditar" Then
            llenarTablaClientesDescripcion()
        End If
    End Sub

    Public Sub llenarTablaClienteMostrarMarca()
        Dim objCliProg As New Negocios.ClientesProgramacionBU
        Dim dtDatosClienteConsulta As New DataTable
        btnAgregarCLientes.Visible = True
        lblAgregar.Visible = True
        dtDatosClienteConsulta = objCliProg.llenarListaClientesConsulta(idMarca)
        grdClientes.DataSource = dtDatosClienteConsulta

        With grdClientes.DisplayLayout.Bands(0)
            .Columns("clie_clienteid").Hidden = True
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("ticl_nombre").Header.Caption = "Tipo de Cliente"
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("ticl_nombre").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Public Sub llenarTablaMostrarTodosLosCLientes()
        Dim objClientes As New Negocios.ClientesProgramacionBU
        Dim dtDatosClientes As New DataTable
        dtDatosClientes = objClientes.mostrarTodosLosClientes(idMarca)
        grdClientes.DataSource = Nothing
        grdClientes.DataSource = dtDatosClientes

        Me.grdClientes.DisplayLayout.Bands(0).Columns.Add("selectClienteImagen", "")
        Dim colckbCr As UltraGridColumn = grdClientes.DisplayLayout.Bands(0).Columns("selectClienteImagen")
        colckbCr.Width = 30
        colckbCr.Header.Caption = "Clientes"
        colckbCr.Style = ColumnStyle.Image

        With grdClientes.DisplayLayout.Bands(0)
            .Columns("clie_clienteid").Hidden = True
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("ticl_nombre").Header.Caption = "Tipo de Cliente"
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("ticl_nombre").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        btnGuardar.Visible = False
        lblGuardar.Visible = False
    End Sub

    Public Sub llenarTablaClientesDescripcion()
        Dim objClientes As New Negocios.ClientesProgramacionBU
        Dim dtDatosClientes As New DataTable
        Dim dtDescripciones As New DataTable

        Me.Width = 870

        dtDatosClientes = objClientes.mostrarClientesColeccionMarca(idMarca, idColeccion)
        dtDatosClientes.Columns.Add("IdDesModelo")
        dtDatosClientes.Columns.Add("DescripcionModelo")
        dtDescripciones = objClientes.mostrarDescripcionPorModelo(idModelo)

        For Each rowDtDatos As DataRow In dtDatosClientes.Rows
            For Each rowDtDesc As DataRow In dtDescripciones.Rows
                If rowDtDatos.Item("clie_clienteid").ToString = rowDtDesc.Item("cldm_clienteid").ToString Then
                    rowDtDatos.Item("IdDesModelo") = rowDtDesc.Item("cldm_clientemodelodescripcionid").ToString
                    rowDtDatos.Item("DescripcionModelo") = rowDtDesc.Item("cldm_descripcion").ToString
                End If
            Next
        Next

        grdClientes.DataSource = dtDatosClientes
        Dim colckbCr As UltraGridColumn = grdClientes.DisplayLayout.Bands(0).Columns("DescripcionModelo")
        colckbCr.MaxLength = 50
        colckbCr.Width = 250
        colckbCr.CharacterCasing = CharacterCasing.Upper
        With grdClientes.DisplayLayout.Bands(0)
            .Columns("clie_clienteid").Hidden = True
            .Columns("IdDesModelo").Hidden = True
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("ticl_nombre").Header.Caption = "Tipo de Cliente"
            .Columns("DescripcionModelo").Header.Caption = "Descripción Personalizada"
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("ticl_nombre").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdClientes.DisplayLayout.Bands(0).Columns("DescripcionModelo").Width = 450
    End Sub

    Public Sub llenarTablaMostrarClientesAgregar()
        Dim objClientes As New Negocios.ClientesProgramacionBU
        Dim dtDatosClientes As New DataTable
        dtDatosClientes = objClientes.mostrarClientesAgregarConsulta(idMarca)
        grdClientes.DataSource = Nothing
        grdClientes.DataSource = dtDatosClientes

        With grdClientes.DisplayLayout.Bands(0)
            .Columns("clie_clienteid").Hidden = True
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("ticl_nombre").Header.Caption = "Tipo de Cliente"
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("ticl_nombre").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        Dim colckbCr As UltraGridColumn = grdClientes.DisplayLayout.Bands(0).Columns("relacion")
        colckbCr.Width = 60
        colckbCr.Header.Caption = "Selección"
        colckbCr.Style = ColumnStyle.CheckBox
    End Sub

    Private Sub btnAgregarCLientes_Click(sender As Object, e As EventArgs) Handles btnAgregarCLientes.Click
        If todosClientes = False Then
            llenarTablaMostrarClientesAgregar()
            btnAgregarCLientes.Image = Global.Programacion.Vista.My.Resources.Resources.cancelar_32
            lblAgregar.Text = "Cancelar"
            btnGuardar.Visible = True
            lblGuardar.Visible = True
            todosClientes = True
        Else
            llenarListaClientes()
            btnAgregarCLientes.Image = Global.Programacion.Vista.My.Resources.Resources.agregar_32
            lblAgregar.Text = "Agregar"
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            todosClientes = False
        End If
    End Sub

    Private Sub grdClientes_BeforeRowFilterDropDown(sender As Object, e As BeforeRowFilterDropDownEventArgs) Handles grdClientes.BeforeRowFilterDropDown

    End Sub

    Private Sub grdClientes_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdClientes.DoubleClickCell
        If e.Cell.Column.Key = "selectClienteImagen" Then
            pIdClienteList = CInt(grdClientes.Rows(e.Cell.Row.Index).Cells("clie_clienteid").Value.ToString)
            pNombreCliente = grdClientes.Rows(e.Cell.Row.Index).Cells("clie_nombregenerico").Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            guardarCambios()
        Catch ex As Exception

        End Try

    End Sub


    Public Sub guardarCambios()
        Dim objMsjConf As New Tools.ConfirmarForm

        If accionFormulario = "consultaCMarcas" Then
            Dim contRegistros As Int32 = 0
            For Each rowGrd As UltraGridRow In grdClientes.Rows
                If CBool(rowGrd.Cells("relacion").Value) Then
                    contRegistros += 1
                End If
            Next
            If contRegistros > 0 Then
                objMsjConf.mensaje = "Estas seguro de guardar los cambios"
                If objMsjConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    guardarRelacion()
                    Dim objMensajeExito As New Tools.ExitoForm
                    objMensajeExito.mensaje = "El registro se realizó con éxito"
                    objMensajeExito.ShowDialog()
                End If
            Else
                If MsgBox("No seleccionaste cliente. ¿Deseas guardar los cambios sin relacionar la marca con ningún cliente?", MsgBoxStyle.YesNo, "Atención") = MsgBoxResult.Yes Then
                    guardarRelacion()
                End If
            End If
            llenarListaClientes()
            btnAgregarCLientes.Image = Global.Programacion.Vista.My.Resources.Resources.agregar_32
            lblAgregar.Text = "Agregar"
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            todosClientes = False

        ElseIf accionFormulario = "descripcionEspecialClienteEditar" Then
            objMsjConf.mensaje = "Estas seguro de guardar los cambios"
            If objMsjConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                guardarDescripcion()
                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "El registro se realizó con éxito"
                objMensajeExito.ShowDialog()
                MsgBox("La pantalla se cerrará.")
                Me.Close()
            End If
        End If
    End Sub




    Public Sub guardarRelacion()
        Dim objClientes As New Negocios.ClientesProgramacionBU
        objClientes.inactivarRelacionMarcaCliente(idMarca)
        For Each rowGrd As UltraGridRow In grdClientes.Rows
            If CBool(rowGrd.Cells("relacion").Value) = True Then
                objClientes.registrarRelacionMarcaCLiente(idMarca, CInt(rowGrd.Cells("clie_clienteid").Value))
            End If
        Next
    End Sub

    Public Sub guardarDescripcion()
        Dim objClientes As New Negocios.ClientesProgramacionBU
        Dim idDescripcion As Int32
        Dim idCliente As Int32
        Dim descripcion As String

        For Each rowDT As UltraGridRow In grdClientes.Rows
            idCliente = CInt(rowDT.Cells("clie_clienteid").Value.ToString)
            descripcion = Trim(rowDT.Cells("DescripcionModelo").Value.ToString)

            If rowDT.Cells("IdDesModelo").Value.ToString <> "" Then
                idDescripcion = CInt(rowDT.Cells("IdDesModelo").Value.ToString)
            Else
                idDescripcion = 0
            End If

            If (rowDT.Cells("DescripcionModelo").Value.ToString <> Nothing Or rowDT.Cells("IdDesModelo").Value.ToString <> Nothing) Then
                objClientes.registrarClienteDescripcionModelo(idDescripcion, idCliente, idModelo, descripcion)
            End If
        Next
    End Sub

    Private Sub grdClientes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdClientes.InitializeRow
        If e.Row.Cells.Exists("selectClienteImagen") Then
            e.Row.Cells("selectClienteImagen").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub
End Class