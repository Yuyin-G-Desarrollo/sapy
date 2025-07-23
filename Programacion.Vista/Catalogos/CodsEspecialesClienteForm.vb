Imports Infragistics.Win.UltraWinGrid

Public Class CodsEspecialesClienteForm
    Public idCliente As Integer
    Private lstPreciosCli As New DataTable
    Dim code As String
    Dim claveECO As String
    Dim editar As Boolean = False
    '//MÉTODOS
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub CodsEspecialesClienteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboListasPreciosCliente()
        lblEstado.Text = " "
        code = " "
        claveECO = " "
    End Sub
    Private Sub cmbListaPrecios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaPrecios.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        llenarTextFechasVigencia()
        Me.Cursor = Cursors.Default
    End Sub
    Public Function getOpcionVerProductosDe() As Integer
        Dim verProductos As Integer
        If rdo1.Checked Then
            verProductos = 1
        ElseIf rdo2.Checked Then
            verProductos = 2
        Else
            verProductos = 3
        End If
        Return verProductos
    End Function
    Public Function getOpcionConCodigo() As Integer
        Dim conCodigo As Integer
        If rdo4.Checked Then
            conCodigo = 1
        ElseIf rdo5.Checked Then
            conCodigo = 2
        Else
            conCodigo = 3
        End If
        Return conCodigo
    End Function
    Public Function getOpcionActivos() As Integer
        Dim activos As Integer
        If rdo7.Checked Then
            activos = 1
        Else
            activos = 2
        End If
        Return activos
    End Function
    Public Sub disenioGridAllowEdit()
        Try
            editar = True
            With grd1.DisplayLayout.Bands(0)
                .Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("CLaveECO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            End With
        Catch
        End Try
    End Sub
    Public Sub disenioGridNoEdit()
        editar = False
        With grd1.DisplayLayout.Bands(0)
            .Columns("ModeloYuyin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Modificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("MotivoEliminación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Usuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Corrida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ModeloCliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Linea").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Material").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Color").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CLaveECO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End With
    End Sub
    Public Sub disenioGrid()
        With grd1.DisplayLayout.Bands(0)
            .Columns("codigoproductoestiloid").Hidden = True
            .Columns("ProductoEstiloID").Hidden = True
            .Columns("Marca").Hidden = True
            .Columns("Coleccion").Hidden = True
            .Columns("IdColorSAY").Hidden = True
            .Columns("IdTallaSAY").Hidden = True
            .Columns("ProductoID").Hidden = True
            .Columns("talla_inicio").Hidden = True
            .Columns("talla_fin").Hidden = True
            .Columns("MaterialYuyin").Hidden = True
            .Columns("ColorYuyin").Hidden = True
            '.Columns("Seleccion").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
            .Columns("Seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            '.Columns("Seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
            .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Seleccion").Style = ColumnStyle.CheckBox
            .Columns("Seleccion").Header.Caption = " "
            .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("ModeloYuyin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Modificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Modificación").Format = "dd/MM/yy H:mm:ss"
            .Columns("MotivoEliminación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Usuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Corrida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ModeloCliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Linea").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Material").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Color").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If Not editar Then
                .Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("ClaveECO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .Columns("ModeloYuyin").Width = 190
            .Columns("Modificación").Width = 85
            .Columns("Corrida").Width = 50
            .Columns("Seleccion").Width = 4
            .Columns("ModeloCliente").Width = 80
            .Columns("Linea").Width = 50
            .Columns("Material").Width = 90
            .Columns("Color").Width = 90
            .Columns("Code").Width = 50
            .Columns("ClaveECO").Width = 70
            .Columns("Code").MaxLength = 9
            .Columns("Code").CharacterCasing = CharacterCasing.Upper
            .Columns("ClaveECO").MaxLength = 9
            .Columns("ClaveECO").CharacterCasing = CharacterCasing.Upper
        End With
        grd1.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grd1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grd1.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

    End Sub
    Public Sub disenioGrid2()
        With grd2.DisplayLayout.Bands(0)
            .Columns("cocl_codigosclientesid").Hidden = True
            .Columns("TallaEspecial").Hidden = True
            .Columns("ModeloYuyin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Modificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Usuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Corrida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Material").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Color").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CodRápido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ClaveECO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Código").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Talla").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .Columns("Modificación").Format = "dd/MM/yy H:mm:ss"
            .Columns("Modificación").Width = 75
            .Columns("ModeloYuyin").Width = 190
            .Columns("Corrida").Width = 38
            .Columns("Material").Width = 90
            .Columns("Color").Width = 90
            .Columns("ClaveECO").Width = 70
            .Columns("Código").Width = 65
        End With
        grd2.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grd2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grd2.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

    End Sub
    Public Function getIdEliminar() As String
        Dim cadena As String
        Dim ban As Integer
        cadena = ""
        For Each row As UltraGridRow In grd1.Rows
            If CBool(row.Cells("Seleccion").Value) Then
                If ban = 1 Then
                    cadena += ","
                End If
                cadena += "" + row.Cells("codigoproductoestiloid").Text
                ban = 1
            End If
        Next
        Return cadena
    End Function
    ''' <summary>
    ''' FALTA ELIMINAR SUS DERIVADOS
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub eliminarCodigos(ByVal motivo As String)
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Dim mensj As String
        mensj = objBU.CambiarEstatusInactivoCodsProdsEstilo(getIdEliminar(), motivo)
        If mensj.Contains("Error") Then
            Dim objMensajeError As New Tools.ErroresForm
            objMensajeError.mensaje = mensj
            objMensajeError.ShowDialog()
        Else
            llenarTablaCodigosProductoEstilo()
            grd2.DataSource = Nothing
        End If
        Me.Cursor = Cursors.Default
    End Sub

    '///Llenar componentes
    Public Sub llenarComboListasPreciosCliente()
        Dim datoslistarPrecios As New Programacion.Negocios.CodigosEspecialesClienteBU

        lstPreciosCli = datoslistarPrecios.ListasPreciosCliente(idCliente)
        If Not lstPreciosCli.Rows.Count = 0 Then
            lstPreciosCli.Rows.InsertAt(lstPreciosCli.NewRow, 0)
            cmbListaPrecios.DataSource = lstPreciosCli
            cmbListaPrecios.DisplayMember = "Lista"
            cmbListaPrecios.ValueMember = "idListaVentasClientePrecio"
        End If
    End Sub
    Public Sub llenarTextFechasVigencia()
        If cmbListaPrecios.SelectedIndex > 0 Then
            Dim datoslistarPrecios As New Programacion.Negocios.CodigosEspecialesClienteBU
            Dim lstPreCli = datoslistarPrecios.ListasPreciosClienteFechas(cmbListaPrecios.SelectedValue)
            If Not lstPreCli.Rows.Count = 0 Then
                Dim row As DataRow = lstPreCli.Rows(lstPreCli.Rows.Count - 1)
                Dim f As Object
                Dim f2 As Object
                f = row.Item("InicioVigencia")
                f2 = row.Item("FinVigencia")
                If f Is DBNull.Value Then
                    txtFecha1.Text = "Sin Fecha"
                Else
                    txtFecha1.Text = CStr(f)
                End If
                If f2 Is DBNull.Value Then
                    txtFecha2.Text = "Sin Fecha"
                Else
                    txtFecha2.Text = CStr(f2)
                End If
            End If
        Else
            txtFecha1.Text = " "
            txtFecha2.Text = " "
            grd2.DataSource = Nothing
            grd1.DataSource = Nothing
        End If
    End Sub
    Public Sub llenarTablaCodigosProductoEstilo()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Dim dtCodigosCli As New DataTable
        grd1.DataSource = Nothing
        grd3.DataSource = Nothing

        If rdo2.Checked Then
            If cmbListaPrecios.SelectedIndex > 0 Then
                dtCodigosCli = objBU.LlenarTabla1(getOpcionVerProductosDe(), getOpcionConCodigo(), getOpcionActivos(), cmbListaPrecios.SelectedValue, idCliente)
                If dtCodigosCli.Rows.Count > 0 Then
                    grd1.DataSource = dtCodigosCli
                    grd3.DataSource = dtCodigosCli
                    disenioGrid()
                Else
                    grd1.DataSource = Nothing
                    grd3.DataSource = Nothing
                End If
            Else
                grd1.DataSource = Nothing
                grd3.DataSource = Nothing
                Dim objMensaje As New Tools.AvisoForm
                objMensaje.mensaje = "Seleccione una lista de precio."
                objMensaje.ShowDialog()
            End If
        Else
            Dim lp As Integer = 0
            If Not IsDBNull(cmbListaPrecios.SelectedValue) Then
                lp = cmbListaPrecios.SelectedValue
            End If
            dtCodigosCli = objBU.LlenarTabla1(getOpcionVerProductosDe(), getOpcionConCodigo(), getOpcionActivos(), lp, idCliente)
            If dtCodigosCli.Rows.Count > 0 Then
                grd1.DataSource = dtCodigosCli
                grd3.DataSource = dtCodigosCli
                disenioGrid()
            Else
                grd1.DataSource = Nothing
                grd3.DataSource = Nothing
            End If
            End If
            Me.Cursor = Cursors.Default
    End Sub
    Public Sub llenarTablaCodigosClientes()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Dim dtCodigosCli As New DataTable
        grd2.DataSource = Nothing
        Try
            dtCodigosCli = objBU.getCodigosClientes(grd1.ActiveRow.Cells("ProductoID").Value, idCliente, grd1.ActiveRow.Cells("ProductoEstiloID").Value,
                                                               grd1.ActiveRow.Cells("ClaveECO").Value, grd1.ActiveRow.Cells("IdTallaSAY").Value)

        Catch ex As Exception

        End Try
               
                If dtCodigosCli.Rows.Count > 0 Then
                    grd2.DataSource = dtCodigosCli
                    disenioGrid2()
                Else
                    grd2.DataSource = Nothing
                End If
                Me.Cursor = Cursors.Default
    End Sub
    '//Métodos componentes
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pnlParametros.Height = 122
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pnlParametros.Height = 35
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        disenioGridAllowEdit()
    End Sub
    Private Sub btnDetener_Click(sender As Object, e As EventArgs) Handles btnDetener.Click
        disenioGridNoEdit()
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "¿Esta seguro que desea Agregar/Editar este código de cliente? (Los códigos editados quedarán como activos)"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            eliminarCodigos(EliminarCodigosClientes())
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        llenarTablaCodigosProductoEstilo()
        grd2.DataSource = Nothing
    End Sub
    Private Sub grd1_Error(sender As Object, e As ErrorEventArgs) Handles grd1.Error
        If e.ErrorText.Contains("Unable to update the data value: No se puede obtener acceso al objeto desechado.") Then
            e.Cancel = True
        End If
    End Sub
    Private Sub grd1_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grd1.BeforeCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.ToString = "Code" Then
                If Not IsDBNull(e.NewValue.ToString) Then
                    code = e.NewValue.ToString
                Else
                    code = ""
                End If
                If Not IsDBNull(grd1.ActiveRow.Cells("ClaveECO").Value) Then
                    claveECO = grd1.ActiveRow.Cells("ClaveECO").Value
                Else
                    claveECO = ""
                End If

            ElseIf e.Cell.Column.ToString = "ClaveECO" Then
                If Not IsDBNull(e.NewValue.ToString) Then
                    claveECO = e.NewValue.ToString
                Else
                    claveECO = ""
                End If
                If Not IsDBNull(grd1.ActiveRow.Cells("Code").Value) Then
                    code = grd1.ActiveRow.Cells("Code").Value
                Else
                    code = ""
                End If
            End If
        End If
    End Sub
    Private Sub actualizarCodigosClientes(ByVal idCodigoProdEstilo As Integer)
        Dim lista As New List(Of String)
        Dim codigos As New DataTable
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Dim motivo As String = ""
        codigos = objBU.getListaIdCodigosClientes(grd1.ActiveRow.Cells("ProductoEstiloID").Value)
        For Each row2 As DataRow In codigos.Rows
            lista.Add(row2("cocl_codigosclientesid").ToString)
        Next

        Dim codigosCliente = armarCodigos(grd1.ActiveRow.Cells("claveECO").Value, grd1.ActiveRow.Cells("IdTallaSAY").Value)
        Dim tallas = getTallastade_talla(grd1.ActiveRow.Cells("IdTallaSAY").Value)
        Dim ban As Integer
        ban = 0
        For Each codigocliente As String In codigosCliente
            If codigocliente = Nothing Then
                'No hay talla
            Else
                objBU.UpdateCodigosClientes(lista.Item(ban), grd1.ActiveRow.Cells("ProductoEstiloID").Value, codigocliente, grd1.ActiveRow.Cells("ModeloCliente").Value,
                                            grd1.ActiveRow.Cells("Marca").Value, grd1.ActiveRow.Cells("Coleccion").Value,
                                            grd1.ActiveRow.Cells("Linea").Value, grd1.ActiveRow.Cells("MaterialYuyin").Value, grd1.ActiveRow.Cells("ColorYuyin").Value,
                                            tallas.Item(ban))
            End If
            ban = ban + 1
        Next

    End Sub
    Private Sub grd1_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles grd1.BeforeRowUpdate
        If e.Row.IsFilterRow = False Then
            If code.Equals(" ") And claveECO.Equals(" ") Then
                'Posible mensaje de completar campos'
            Else
                Me.Cursor = Cursors.WaitCursor
                If Not CBool(grd1.ActiveRow.Cells("Seleccion").Value) Then

                    Dim objMensaje As New Tools.ConfirmarForm
                    objMensaje.mensaje = "¿Estás seguro de guardar los cambios?"
                    If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor
                        If grd1.ActiveRow.Cells("ClaveECO").Value.ToString.Trim.Length = 9 Then
                            Dim objBU As New Negocios.CodigosEspecialesClienteBU
                            Dim mensj As String
                            Dim codigoproductoestiloid As Integer
                            Dim code As String
                            codigoproductoestiloid = grd1.ActiveRow.Cells("codigoproductoestiloid").Value
                            If IsDBNull(grd1.ActiveRow.Cells("Code").Value) Then
                                code = ""
                            Else
                                code = grd1.ActiveRow.Cells("Code").Value
                            End If
                            mensj = objBU.InsertUpdateCodigosProductoEstilo(codigoproductoestiloid, grd1.ActiveRow.Cells("ProductoEstiloID").Value, grd1.ActiveRow.Cells("ClaveECO").Value,
                                                                          code, idCliente)

                            If mensj.Contains("Error") Then
                                Dim objMensajeError As New Tools.ErroresForm
                                objMensajeError.mensaje = mensj
                                objMensajeError.ShowDialog()
                            Else
                                If codigoproductoestiloid = 0 Then
                                    'Generación de códigos
                                    guardarCodigosGenerados()
                                    llenarTablaCodigosClientes()
                                    llenarTablaCodigosProductoEstilo()
                                    'llenarTablaColores()
                                Else
                                    If codigoproductoestiloid > 0 Then
                                        actualizarCodigosClientes(codigoproductoestiloid)
                                        llenarTablaCodigosClientes()
                                        llenarTablaCodigosProductoEstilo()
                                    End If
                                    Me.Cursor = Cursors.Default
                                End If
                                code = " "
                                claveECO = " "
                            End If
                        Else
                            Dim objMensaj As New Tools.AvisoForm
                            objMensaj.mensaje = "La ClaveECO debe tener una longitud de 9 dígitos, es necesario actualizar el registro  y capturar los caracteres faltantes"
                            objMensaj.ShowDialog()
                        End If
                    Else
                        e.Cancel = True

                    End If
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ''' <summary>
    ''' Genera la lista de códigosClientes, ClaveECO + Talla + Dígito verificador EAN13 
    ''' </summary>
    ''' <returns>Genera la lista de códigosClientes</returns>
    ''' <remarks></remarks>
    Public Function armarCodigos(ByVal claveECO As String, ByVal idTalla As Integer) As List(Of String)
        Dim codigosCliente As New List(Of String)
        Dim tallas = getTallas(idTalla)
        For Each t As String In tallas
            If t = Nothing Then
                codigosCliente.Add("") 'tade_tallaespecial from Programacion.TallasDetalle NO TIENE VALOR EN EL CAMPO
            Else
                codigosCliente.Add(getDigitoVerificador(claveECO & "" & t))
            End If
        Next
        Return codigosCliente
    End Function
    Public Function getDigitoVerificador(ByVal digitos As String) As String
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Return objBU.getDigitoVerificador(digitos)
    End Function
    Public Function getTallas(ByVal idTallaSay As Integer) As List(Of String)
        Dim list As New List(Of String)
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Dim tallasEspeciales As New DataTable
        tallasEspeciales = objBU.getTallasIdsSAY(idTallaSay)
        For Each row As DataRow In tallasEspeciales.Rows
            list.Add(row("tade_tallaespecial").ToString)
        Next
        Return list
    End Function
    Public Function getTallastade_talla(ByVal idTallaSay As Integer) As List(Of String)
        Dim list As New List(Of String)
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Dim tallasEspeciales As New DataTable
        tallasEspeciales = objBU.getTallasIdsSAY(idTallaSay)
        For Each row As DataRow In tallasEspeciales.Rows
            list.Add(row("tade_talla").ToString)
        Next
        Return list
    End Function
    Private Sub btnImpCod_Click(sender As Object, e As EventArgs) Handles btnImpCod.Click
        Me.Cursor = Cursors.WaitCursor
        lblEstado.Text = "Importando Excel"
        ImportarExcel()
        lblEstado.Text = ""
        grd2.DataSource = Nothing
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub guardarCodigosGenerados()
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Dim codigosCliente = armarCodigos(grd1.ActiveRow.Cells("claveECO").Value, grd1.ActiveRow.Cells("IdTallaSAY").Value)
        Dim tallas = getTallastade_talla(grd1.ActiveRow.Cells("IdTallaSAY").Value)
        Dim ban As Integer
        ban = 0
        For Each codigocliente As String In codigosCliente
            If codigocliente = Nothing Then
                'No hay talla
            Else
                objBU.InsertCodigosClientes(idCliente, grd1.ActiveRow.Cells("ProductoEstiloID").Value, codigocliente, grd1.ActiveRow.Cells("ModeloCliente").Value,
                                            grd1.ActiveRow.Cells("Marca").Value, grd1.ActiveRow.Cells("Coleccion").Value,
                                          grd1.ActiveRow.Cells("Linea").Value, grd1.ActiveRow.Cells("MaterialYuyin").Value, grd1.ActiveRow.Cells("ColorYuyin").Value,
                                          tallas.Item(ban))
            End If
            ban = ban + 1
        Next
    End Sub
    Private Sub grd1_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grd1.DoubleClickRow
        If grd1.ActiveRow.Index > -1 Then
            If grd1.ActiveRow.Cells("codigoproductoestiloid").Value > 0 Then
                llenarTablaCodigosClientes()
            Else
                Dim objMensaje As New Tools.AvisoForm
                objMensaje.mensaje = "No existen registros"
                objMensaje.ShowDialog()
                grd2.DataSource = Nothing
            End If
        End If
    End Sub
    Private Function EliminarCodigosClientes() As String
        Dim lista As New List(Of String)
        Dim codigos As New DataTable
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Dim formEliminacion As New CodigosCliente_MotivoEliminacionForm
        Dim motivo As String = " "
        With formEliminacion
            formEliminacion.ShowDialog()
            motivo = formEliminacion.txtMotivo.Text
            formEliminacion.Dispose()
        End With

        For Each row As UltraGridRow In grd1.Rows
            If CBool(row.Cells("Seleccion").Value) Then
                codigos = objBU.getListaIdCodigosClientes(row.Cells("ProductoEstiloID").Value)
                For Each row2 As DataRow In codigos.Rows
                    lista.Add(row2("cocl_codigosclientesid").ToString)
                Next
                For Each cod As String In lista
                    objBU.InactivarCodigosClientes(Int(cod), motivo)
                Next
                lista.Clear()
            End If
        Next
        Return motivo
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        llenarComboListasPreciosCliente()
        grd1.DataSource = Nothing
        grd2.DataSource = Nothing
        cmbListaPrecios.SelectedIndex = 0
        txtFecha1.Text = ""
        txtFecha2.Text = ""
    End Sub
    Private Sub grd1_KeyDown(sender As Object, e As KeyEventArgs) Handles grd1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                grd1.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grd1.DisplayLayout.Bands(0)
                If grd1.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grd1.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grd1.ActiveCell = nextRow.Cells(grd1.ActiveCell.Column)
                    e.Handled = True
                    grd1.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ExportarGridAExcel()
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
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
                Dim datos As DataTable = objBU.getAllCodigosClientes(idCliente)
                grd4.DataSource = datos
                ultExportGrid.Export(grd4, fileName)
                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()

                Process.Start(fileName)

                grd4.DataSource = Nothing
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ExportarGridAExcel2()

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

                ultExportGrid.Export(grd3, fileName)

                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)

                grd3.DataSource = Nothing
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnExpCod_Click(sender As Object, e As EventArgs) Handles btnExpCod.Click
        ExportarGridAExcel()
    End Sub
    Private Sub btnExpImp_Click(sender As Object, e As EventArgs) Handles btnExpImp.Click
        llenargrid3()
        If Not grd3.DataSource Is Nothing Then
            ExportarGridAExcel2()
        End If

    End Sub
    Private Sub llenargrid3()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Dim dtCodigosCli As New DataTable
        grd3.DataSource = Nothing
        Dim lp As Integer = 0
        If Not IsDBNull(cmbListaPrecios.SelectedValue) Then
            lp = cmbListaPrecios.SelectedValue
        End If
        dtCodigosCli = objBU.LlenarTabla2(getOpcionVerProductosDe(), getOpcionConCodigo(), getOpcionActivos(), lp, idCliente)
        If dtCodigosCli.Rows.Count > 0 Then
            grd3.DataSource = dtCodigosCli
        Else
            grd3.DataSource = Nothing
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ImportarExcel()
        Dim mensaje As String = "Registrados correctamente."
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Dim datosExcel As New DataTable
        Dim datosIds As New DataTable
        Dim datos2 As New DataTable
        Dim idCodigoProductoEstilo As Integer = 0
        Dim productoEstiloID As String = ""
        Dim NombreArchivo As String = ""
        Dim ban As Integer = 0
        Try
            Dim hoja As String = ""
            datosExcel = Tools.Excel.LlenarTablaExcelListaTablas(hoja, "", NombreArchivo)
            If datosExcel.Rows.Count > 0 Then
                For Each r As DataRow In datosExcel.Rows
                    If Not r(9).ToString() = "" Then 'No hay clave ECO
                        If Not r(2).ToString() = "" Then 'No hay modelo
                            If r(9).ToString().Length = 9 Then

                                datosIds = objBU.validarInsercionCodigos(r(2).ToString().Trim, r(3).ToString().Trim, r(4).ToString().Trim, r(6).ToString().Trim.Substring(0, 2), idCliente)
                                If datosIds.Rows.Count > 0 Then 'Existe un registro 
                                    For Each row As DataRow In datosIds.Rows
                                        productoEstiloID = Int(row("ProductoEstiloID").ToString)
                                        Exit For
                                    Next
                                    datosIds = objBU.getIdsCodigos(productoEstiloID, idCliente, r(9).ToString(), 1)
                                    If datosIds.Rows.Count > 0 Then
                                        datos2 = objBU.getIdsCodigos(productoEstiloID, idCliente, r(9).ToString(), 2)

                                        If datos2.Rows.Count > 0 Then 'El registro coincide totalmente no es necesesario modificar nada

                                        Else 'El registro no coincide el la claveECO (modificarCodigos)
                                            For Each row As DataRow In datosIds.Rows
                                                idCodigoProductoEstilo = Int(row("cope_codigoproductoestiloid").ToString)
                                                'objBU.actualizarCodigoECOySecundario(r(9).ToString(), r(8).ToString(), idCliente, Int(row("cocl_codigosclientesid").ToString), 2)
                                                actualizarCodigosClientesExcel(idCodigoProductoEstilo, row("cope_productoestiloid").ToString, r(9).ToString())
                                                Exit For
                                            Next
                                            objBU.actualizarCodigoECOySecundario(r(9).ToString(), r(8).ToString(), idCliente, idCodigoProductoEstilo, 1)

                                        End If
                                    Else 'El registro no existe
                                        datos2 = objBU.validarInsercionCodigos(r(2).ToString().Trim, r(3).ToString().Trim, r(4).ToString().Trim, r(6).ToString().Trim.Substring(0, 2), idCliente)
                                        If datos2.Rows.Count > 0 Then
                                            insertarCodigosExcel(datos2, r(2).ToString(), r(3).ToString(), r(4).ToString(), r(8).ToString(), r(9).ToString())

                                        Else 'No cumple con las condiciones para insertar los códigos
                                            mensaje = "Algunos códigos no cumplieron con las condiciones para registrarlos, revise que estén registrados los colores y materiales del cliente."
                                        End If
                                    End If
                                End If
                                'r(2).ToString() 'Modelo                         ejm:1764
                                'r(3).ToString() 'Clave de Color Andrea          ejm:CA
                                'r(4).ToString() 'Clave de Material Andrea       ejm:GAM
                                'r(6).ToString() 'Talla Inicial México           ejm:22.0
                                'r(7).ToString() 'Talla Final México             ejm:27.0
                                'r(8).ToString() 'CODE                           ejm:2272467
                                'r(9).ToString() 'CveEco                         ejm:017642547
                            Else
                                ban += 1
                            End If
                        End If
                    End If
                Next
                llenarTablaCodigosProductoEstilo()
                If ban > 0 Then
                    Dim objMensaje As New Tools.AvisoForm
                    objMensaje.mensaje = "Se encontraron " & ban & " registros con ClaveECO con una longitud menor o mayor a 9 dígitos, es necesario actualizar el archivo y capturar los caracteres faltantes, también verifique que el modelo esté capturado."
                    objMensaje.ShowDialog()
                Else
                    Dim objMensaje As New Tools.AvisoForm
                    objMensaje.mensaje = "Códigos importados con éxito."
                    objMensaje.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Dim objMensajeError As New Tools.ErroresForm
            objMensajeError.mensaje = ex.Message
            objMensajeError.ShowDialog()
        End Try
    End Sub
    Public Sub insertarCodigosExcel(ByVal datos As DataTable, ByVal modeloCliente As String, ByVal color As String,
                                    ByVal piel As String, ByVal code As String, ByVal claveECO As String)
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Dim mensj As String = ""
        Dim ban As Integer = 0
        For Each r As DataRow In datos.Rows
            If ban = 0 Then
                mensj = objBU.InsertUpdateCodigosProductoEstilo(0, r("ProductoEstiloID").ToString, claveECO, code, idCliente)
                Dim codigosCliente = armarCodigos(claveECO, r("talla_tallaid").ToString)
                Dim tallas = getTallastade_talla(r("talla_tallaid").ToString)
                ban = 0
                For Each codigocliente As String In codigosCliente
                    If codigocliente = Nothing Then
                        'No hay talla
                    Else
                        objBU.InsertCodigosClientes(idCliente, r("ProductoEstiloID").ToString, codigocliente, modeloCliente,
                                                    r("Marca").ToString, r("Coleccion").ToString,
                                                  r("talla_descripcion").ToString, r("Piel").ToString, r("Color").ToString,
                                                  tallas.Item(ban))
                    End If
                    ban = ban + 1
                Next
                llenarTablaCodigosClientes()
                llenarTablaCodigosProductoEstilo()
            End If
            ban = 1
            Exit For
        Next


    End Sub

    Private Sub grd1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grd1.KeyPress
        If grd1.ActiveRow.HasNextSibling(True) Then
            Dim c As Char = e.KeyChar
            If (c = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                If Not IsNumeric(e.KeyChar) Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub
    Private Sub actualizarCodigosClientesExcel(ByVal idCodigoProdEstilo As Integer, ByVal productoEstiloID As Integer, ByVal claveECO As String)
        Dim lista As New List(Of String)
        Dim codigosCliente As New List(Of String)
        Dim tallas As New List(Of String)
        Dim codigos As New DataTable
        Dim datosProductoEstilo As New DataTable
        Dim objBU As New Negocios.CodigosEspecialesClienteBU
        Dim motivo As String = ""
        codigos = objBU.getListaIdCodigosClientes(productoEstiloID)
        datosProductoEstilo = objBU.getDatosProductoEstilo(productoEstiloID)
        For Each row2 As DataRow In codigos.Rows
            lista.Add(row2("cocl_codigosclientesid").ToString)
        Next
        For Each row2 As DataRow In datosProductoEstilo.Rows
            codigosCliente = armarCodigos(claveECO, row2("IdTallaSAY").ToString)
            tallas = getTallastade_talla(row2("IdTallaSAY").ToString)
            Exit For
        Next
        Dim ban As Integer
        ban = 0
        For Each row2 As DataRow In datosProductoEstilo.Rows
            For Each codigocliente As String In codigosCliente
                If codigocliente = Nothing Then
                    'No hay talla
                Else
                    If ban < lista.Count Then
                        objBU.UpdateCodigosClientes(lista.Item(ban), row2("ProductoEstiloID").ToString, codigocliente, row2("CodigoCliente").ToString,
                                                    row2("Marca").ToString, row2("Coleccion").ToString,
                                                    row2("Linea").ToString, row2("Piel").ToString, row2("Color").ToString,
                                                    tallas.Item(ban))
                    End If
                End If
                ban = ban + 1
            Next
            Exit For
        Next
    End Sub
End Class