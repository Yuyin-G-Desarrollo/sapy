Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.Data
Imports System.ComponentModel
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Data

Public Class AuditoriaPrecioBaseForm

    'variables que uso para poder hacer las conexiones a la bd y obtener los datos y guardar las modificaciones
    Dim objLPB As New Negocios.AuditoriaPrecioBaseBU
    Dim dtDatosListaPrecios As New DataTable
    Dim objClMon As New Negocios.AuditoriaPrecioBaseBU
    Dim objLCBU As New Negocios.AuditoriaPrecioBaseBU

    'arreglo que sirve para guardar los registros que se van a modificar
    Dim Rows As New ArrayList()

    Private Sub AuditoriaPrecioBaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cargo el combo desde que se carga la pantalla
        Me.Top = 0
        Me.Left = 0
        llenarComboListaBase()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click

        If GridView1.DataRowCount - 1 > 0 Then
            Dim filename As String
            Dim DataGrid As DevExpress.XtraGrid.GridControl = GridControl1

            'Ask the user where to save the file to
            Dim SaveFileDialog As New SaveFileDialog()
            SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
            SaveFileDialog.FilterIndex = 2
            SaveFileDialog.RestoreDirectory = True
            If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                'This is required so that excel doesn't make all the grids very small. This will export all grids space out evenly
                GridView1.OptionsPrint.AutoWidth = False

                'Set the selected file as the filename
                filename = SaveFileDialog.FileName

                'Export the file via inbuild function
                DataGrid.ExportToXlsx(filename)

                'If the file exists (i.e. export worked), then open it
                If System.IO.File.Exists(filename) Then
                    Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If DialogResult = Windows.Forms.DialogResult.Yes Then
                        System.Diagnostics.Process.Start(filename)
                    End If
                End If
            End If
        Else
            Dim objMensaje As New Tools.AvisoForm
            objMensaje.mensaje = "Para exportar información, es necesario mostrar datos en la tabla."
            objMensaje.ShowDialog()
        End If
        
    End Sub

    Public Sub llenarComboListaBase()
        Dim objLPB As New Negocios.AuditoriaPrecioBaseBU
        Dim dtDatosListaPrecios As New DataTable
        dtDatosListaPrecios = objLPB.verListaPreciosBase

        'valido que haya lista de precio
        If dtDatosListaPrecios.Rows.Count > 0 Then
            Dim newRow As DataRow = dtDatosListaPrecios.NewRow
            dtDatosListaPrecios.Rows.InsertAt(newRow, 0)
            cmbLstBase.DataSource = dtDatosListaPrecios
            cmbLstBase.DisplayMember = "lpba_nombrelista"
            cmbLstBase.ValueMember = "lpba_listapreciosbaseid"
            cmbLstBase.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        'limpio el grid en caso de que haya datos mostrandose y para que el grid no replique a (#)
        GridView1.Columns.Clear()
        Dim val As Integer
        'precios base en listas de precio...
        If rdoPBase.Checked = True Then

            'lista de precio base seleccionada
            If cmbLstBase.SelectedIndex > 0 Then

                'Me.ComboEmpleado.Column(1)
                'Combo1.ItemData(NewIndex) = Val(codigo)
                'DirectCast(New ArrayList.ArrayListDebugView(cmbLstBase.Items.InnerList).Items(1), DataRowView).Row.ItemArray(2)

                Dim PRUEBA = DirectCast(cmbLstBase.SelectedItem, DataRowView).Row.ItemArray(2)

                If PRUEBA.Equals("AUTORIZADA") Then
                    btnGuardar.Enabled = True
                Else
                    btnGuardar.Enabled = False
                End If

                Me.Cursor = Cursors.WaitCursor
                Dim idLstPrecioBase As Integer = cmbLstBase.SelectedValue.ToString

                'lleno a los datos del cliente según la lista seleccionada
                dtDatosListaPrecios = objLPB.verProductosPrecioBase(idLstPrecioBase)
                GridControl1.DataSource = dtDatosListaPrecios
                Dim i As Integer
                'en la pantalla de alta configuración se hace esta operación parecida, pero aquí se hace desde la base de datos el redondeo
                For i = 0 To GridView1.DataRowCount - 1


                    'comparo la paridad para saber si se le maneja moneda extranjera
                    If GridView1.GetRowCellValue(i, "Paridad Pesos") <> 1 Then

                        'GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Guardado")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), 1))
                        GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round(GridView1.GetRowCellValue(i, "P. Calculado Nuevo"), MidpointRounding.AwayFromZero))

                        ' GridView1.SetRowCellValue(i, "P. Final Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Guardado")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), 1))
                        GridView1.SetRowCellValue(i, "*P. Final Nuevo", Math.Round(GridView1.GetRowCellValue(i, "*P. Final Nuevo"), MidpointRounding.AwayFromZero))

                        'no aplico el redondeo ya que como la moneda es extranjera interesa saber el decimal para
                        'poder convertir a peso mexicano en cálculo a mano
                        GridView1.SetRowCellValue(i, "Paridad P. Base", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), 1))


                    Else
                        GridView1.SetRowCellValue(i, "Paridad P. Base", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                        GridView1.SetRowCellValue(i, "*P. Final Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                        GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round(GridView1.GetRowCellValue(i, "P. Calculado Nuevo"), MidpointRounding.AwayFromZero))


                        ''se aplica el redondeo y se verifica que sean iguales, si hay iguales no los debe mostrar
                        'If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                        '    val += 1
                        '    GridView1.DeleteRow(i)
                        'End If
                        'se vuelve a aplicar el redondeo ya que con el primero sigue mostrando decimales
                        'GridView1.SetRowCellValue(i, "Paridad P. Base", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                        'GridView1.SetRowCellValue(i, "*P. Final Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                        'GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round(GridView1.GetRowCellValue(i, "P. Calculado Nuevo"), MidpointRounding.AwayFromZero))

                        'If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                        '    val += 1
                        '    GridView1.DeleteRow(i)
                        'End If

                    End If

                Next i

                For i = 0 To GridView1.DataRowCount - 1


                    If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                        val += 1
                        GridView1.DeleteRow(i)
                    End If
                Next
                For i = 0 To GridView1.DataRowCount - 1


                    If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                        val += 1
                        GridView1.DeleteRow(i)
                    End If
                Next
                For i = 0 To GridView1.DataRowCount - 1


                    If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                        val += 1
                        GridView1.DeleteRow(i)
                    End If
                Next
                For i = 0 To GridView1.DataRowCount - 1
                    If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                        val += 1
                        GridView1.DeleteRow(i)
                    End If
                Next
                For i = 0 To GridView1.DataRowCount - 1
                    If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                        val += 1
                        GridView1.DeleteRow(i)
                    End If
                Next
                ' MsgBox(val)
                estiloGrd()
                Me.Cursor = Cursors.Default
            Else
                Dim objMensaje As New Tools.AvisoForm
                objMensaje.mensaje = "Para mostrar informacion, es necesario seleccionar una lista base."
                objMensaje.ShowDialog()
                GridControl1.DataSource = DBNull.Value
                GridView1.Columns.Clear()
            End If

            'precios finales en listas de precios...
        ElseIf rdoPFinal.Checked = True Then

            'lista de precio base seleccionada
            If cmbLstBase.SelectedIndex > 0 Then
                Me.Cursor = Cursors.WaitCursor
                Dim idLstPrecioBase As Integer = cmbLstBase.SelectedValue.ToString

                'lleno a los datos del cliente según la lista seleccionada
                dtDatosListaPrecios = objLPB.verProductosPrecioFinal(idLstPrecioBase)
                GridControl1.DataSource = dtDatosListaPrecios

                'en la pantalla de alta configuración se hace esta operación parecida, pero aquí se hace desde la base de datos el redondeo
                For i As Integer = 0 To GridView1.DataRowCount - 1

                    If GridView1.GetRowCellValue(i, "Paridad Pesos") <> 1 Then

                        'GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Guardado")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), 1))
                        GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round(GridView1.GetRowCellValue(i, "P. Calculado Nuevo"), MidpointRounding.AwayFromZero))

                        If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                            GridView1.DeleteRow(i)
                        End If

                        ' GridView1.SetRowCellValue(i, "P. Final Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Guardado")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), 1))
                        GridView1.SetRowCellValue(i, "*P. Final Nuevo", Math.Round(GridView1.GetRowCellValue(i, "*P. Final Nuevo"), MidpointRounding.AwayFromZero))

                        'no aplico el redondeo ya que como la moneda es extranjera interesa saber el decimal para
                        'poder convertir a peso mexicano en cálculo a mano
                        GridView1.SetRowCellValue(i, "Paridad P. Base", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), 1))

                    Else
                        GridView1.SetRowCellValue(i, "Paridad P. Base", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                        GridView1.SetRowCellValue(i, "*P. Final Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                        GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round(GridView1.GetRowCellValue(i, "P. Calculado Nuevo"), MidpointRounding.AwayFromZero))

                        'se aplica el redondeo y se verifica que sean iguales, si hay iguales no los debe mostrar
                        If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                            val += 1
                            GridView1.DeleteRow(i)
                        End If
                        'se vuelve a aplicar el redondeo ya que con el primero sigue mostrando decimales
                        GridView1.SetRowCellValue(i, "Paridad P. Base", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                        GridView1.SetRowCellValue(i, "*P. Final Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                        GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round(GridView1.GetRowCellValue(i, "P. Calculado Nuevo"), MidpointRounding.AwayFromZero))

                    End If

                Next i
                'MsgBox(val)
                'MsgBox(GridView1.DataRowCount)
                estiloGrd()

                Me.Cursor = Cursors.Default
            Else
                Dim objMensaje As New Tools.AvisoForm
                objMensaje.mensaje = "Para mostrar informacion, es necesario seleccionar una lista base."
                objMensaje.ShowDialog()
                GridControl1.DataSource = DBNull.Value
                GridView1.Columns.Clear()               
            End If
        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        'valido que haya filas en el grid para poder limpiar
        If GridView1.RowCount <> 0 Then
            GridControl1.DataSource = DBNull.Value
            GridView1.Columns.Clear()           
            lblRegistros.Text = 0
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "No hay registros que limpiar."
            objMensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim filaConValorError As Integer = 0
        'MsgBox(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)       
        Dim val As Integer
        'lista de precio base seleccionada
        If cmbLstBase.SelectedIndex > 0 Then
            Dim idLstPrecioBase As Integer = cmbLstBase.SelectedValue.ToString

            'valido que haya datos en el grid
            If GridView1.RowCount > 0 Then

                'valido que se hayan seleccionado filas
                If GridView1.SelectedRowsCount() > 0 Then
                    Dim x As Integer = 0
                    'for que añade los valores seleccionados al arreglo
                    For I = 0 To GridView1.SelectedRowsCount() - 1
                        If (GridView1.GetSelectedRows()(I) >= 0) Then
                            Rows.Add(GridView1.GetDataRow(GridView1.GetSelectedRows()(I)))
                        End If
                    Next

                    'for que sirve para verificar si existen reigstros sin asignar valor
                    For x = 0 To Rows.Count - 1
                        Dim Row As DataRow = CType(Rows(x), DataRow)
                        If Row("*P. Final Nuevo").ToString = "" Then
                            filaConValorError += 1
                        End If
                    Next
                    If filaConValorError = 0 Then

                        'mensaje de confirmación para guardar valores cambiados
                        Dim objMsjConfirmar As New Tools.ConfirmarForm
                        Dim cadenaMensaje As String = "¿Desea guardar los cambios de precio de los " + Rows.Count.ToString + "  registros seleccionados? Estos precios serán asignados a los pedidos que se capturen de hoy en adelante. (Una vez realizada esta acción no se podrá revertir)."
                        objMsjConfirmar.mensaje = cadenaMensaje

                        'valido que el mensaje de confirmación sea SI
                        If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then

                            Me.Cursor = Cursors.WaitCursor
                            'for que sirve para actualizar los valores seleccionados a la bd
                            For x = 0 To Rows.Count - 1
                                Dim Row As DataRow = CType(Rows(x), DataRow)

                                'si el precio calculado es diferente a la converción (Paridad P. Base) inserto a paridad
                                'quiere decir que este cliente se le maneja moneda extranjera
                                If Row("P. Calculado Nuevo") <> Row("Paridad P. Base").ToString Then
                                    objLPB.actualizarPrecioCliente(Row("P. Base Actual"), Row("P. Calculado Nuevo"), Row("Paridad P. Base"), Math.Round(Row("*P. Final Nuevo"), MidpointRounding.AwayFromZero), Row("Paridad P. Base"), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Row("Id Lista Precio Cliente Producto"))
                                    
                                    'de lo contrario es un cliente con moneda mexicana y pongo 0 en moneda extranjera (ambos campos)
                                Else
                                    objLPB.actualizarPrecioCliente(Row("P. Base Actual"), Row("P. Calculado Nuevo"), 0, Math.Round(Row("*P. Final Nuevo"), MidpointRounding.AwayFromZero), 0, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Row("Id Lista Precio Cliente Producto"))
                                End If
                            Next

                            Me.Cursor = Cursors.Default
                            Dim objMensajeGuardar As New Tools.ExitoForm
                            objMensajeGuardar.mensaje = "Registros Correctos"
                            objMensajeGuardar.ShowDialog()
                            lblRegistros.Text = 0

                            'se limpia el grid
                            GridView1.Columns.Clear()

                            'una vez actualizado vuelvo a cargar el grid según el radio seleccionado para ver reflejados los cambios hechos
                            'y tomo el mismo proceso del botón mostrar ver comentarios de esa sección
                            If rdoPBase.Checked = True Then
                                Me.Cursor = Cursors.WaitCursor

                                'lleno los datos del cliente
                                dtDatosListaPrecios = objLPB.verProductosPrecioBase(idLstPrecioBase)
                                GridControl1.DataSource = dtDatosListaPrecios

                                'en la pantalla de alta configuración se hace esta operación parecida, pero aquí se hace desde la base de datos el redondeo
                                For i As Integer = 0 To GridView1.DataRowCount - 1

                                    'comparo la paridad para saber si se le maneja moneda extranjera
                                    If GridView1.GetRowCellValue(i, "Paridad Pesos") <> 1 Then

                                        'GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Guardado")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), 1))
                                        GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round(GridView1.GetRowCellValue(i, "P. Calculado Nuevo"), MidpointRounding.AwayFromZero))

                                        'If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                                        '    GridView1.DeleteRow(i)
                                        'End If

                                        ' GridView1.SetRowCellValue(i, "P. Final Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Guardado")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), 1))
                                        GridView1.SetRowCellValue(i, "*P. Final Nuevo", Math.Round(GridView1.GetRowCellValue(i, "*P. Final Nuevo"), MidpointRounding.AwayFromZero))

                                        'no aplico el redondeo ya que como la moneda es extranjera interesa saber el decimal para
                                        'poder convertir a peso mexicano en cálculo a mano
                                        GridView1.SetRowCellValue(i, "Paridad P. Base", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), 1))

                                    Else

                                        'es cuando son clientes con moneda mexicana, se hace la división sobre la paridad que es 1
                                        GridView1.SetRowCellValue(i, "*P. Final Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos"))))
                                        GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                                        'GridView1.SetRowCellValue(i, "*P. Final Nuevo", Math.Round(GridView1.GetRowCellValue(i, "*P. Final Nuevo"), MidpointRounding.AwayFromZero))

                                        'se toma como valor a mostrar en pesos ya que no tiene paridad con otro tipo de moneda
                                        GridView1.SetRowCellValue(i, "Paridad P. Base", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))

                                    End If

                                Next i

                                For i = 0 To GridView1.DataRowCount - 1


                                    If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                                        val += 1
                                        GridView1.DeleteRow(i)
                                    End If
                                Next
                                For i = 0 To GridView1.DataRowCount - 1


                                    If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                                        val += 1
                                        GridView1.DeleteRow(i)
                                    End If
                                Next
                                For i = 0 To GridView1.DataRowCount - 1


                                    If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                                        val += 1
                                        GridView1.DeleteRow(i)
                                    End If
                                Next
                                For i = 0 To GridView1.DataRowCount - 1
                                    If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                                        val += 1
                                        GridView1.DeleteRow(i)
                                    End If
                                Next
                                For i = 0 To GridView1.DataRowCount - 1
                                    If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                                        val += 1
                                        GridView1.DeleteRow(i)
                                    End If
                                Next

                                lblRegistros.Text = 0
                                estiloGrd()
                                Me.Cursor = Cursors.Default

                            ElseIf rdoPFinal.Checked = True Then

                                Me.Cursor = Cursors.WaitCursor
                                dtDatosListaPrecios = objLPB.verProductosPrecioFinal(idLstPrecioBase)
                                GridControl1.DataSource = dtDatosListaPrecios

                                For i As Integer = 0 To GridView1.DataRowCount - 1

                                    'comparo la paridad para saber si se le maneja moneda extranjera
                                    If GridView1.GetRowCellValue(i, "Paridad Pesos") <> 1 Then

                                        'GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Guardado")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), 1))
                                        GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round(GridView1.GetRowCellValue(i, "P. Calculado Nuevo"), MidpointRounding.AwayFromZero))

                                        If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                                            GridView1.DeleteRow(i)
                                        End If

                                        ' GridView1.SetRowCellValue(i, "P. Final Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Guardado")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), 1))
                                        GridView1.SetRowCellValue(i, "*P. Final Nuevo", Math.Round(GridView1.GetRowCellValue(i, "*P. Final Nuevo"), MidpointRounding.AwayFromZero))

                                        'no aplico el redondeo ya que como la moneda es extranjera interesa saber el decimal para
                                        'poder convertir a peso mexicano en cálculo a mano
                                        GridView1.SetRowCellValue(i, "Paridad P. Base", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), 1))

                                    Else
                                        GridView1.SetRowCellValue(i, "Paridad P. Base", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                                        GridView1.SetRowCellValue(i, "*P. Final Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                                        GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round(GridView1.GetRowCellValue(i, "P. Calculado Nuevo"), MidpointRounding.AwayFromZero))

                                        If GridView1.GetRowCellValue(i, "P. Calculado Nuevo") = GridView1.GetRowCellValue(i, "P. Final") Then
                                            val += 1
                                            GridView1.DeleteRow(i)
                                        End If
                                        GridView1.SetRowCellValue(i, "Paridad P. Base", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                                        GridView1.SetRowCellValue(i, "*P. Final Nuevo", Math.Round((((GridView1.GetRowCellValue(i, "P. Base Actual")) * (1 + (GridView1.GetRowCellValue(i, "IXP")) / 100)) / GridView1.GetRowCellValue(i, "Paridad Pesos")), MidpointRounding.AwayFromZero))
                                        GridView1.SetRowCellValue(i, "P. Calculado Nuevo", Math.Round(GridView1.GetRowCellValue(i, "P. Calculado Nuevo"), MidpointRounding.AwayFromZero))

                                    End If
                                Next i
                                'MsgBox(val)
                                'MsgBox(GridView1.DataRowCount)
                                estiloGrd()
                                lblRegistros.Text = 0
                                Me.Cursor = Cursors.Default

                            End If
                        End If
                    Else
                        Dim objMensaje As New Tools.ErroresForm
                        objMensaje.mensaje = "Existen registros seleecionados que no se asignó valor."
                        objMensaje.ShowDialog()
                    End If
                Else
                    Dim objMensaje As New Tools.AdvertenciaForm
                    objMensaje.mensaje = "No se han seleccionado registros."
                    objMensaje.ShowDialog()
                End If
            Else
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "No hay registros que seleccionar."
                objMensaje.ShowDialog()
            End If
        Else
            Dim objMensaje As New Tools.AvisoForm
            objMensaje.mensaje = "Para guardar información, es necesario seleccionar una lista base."
            objMensaje.ShowDialog()
        End If

        'limpio el arreglo para que no quedé ningún registro y ocasione problemas
        Rows.Clear()

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()

    End Sub

    Public Sub estiloGrd()

        'Adecuar ancho del indicador de renglón en el grid
        GridView1.IndicatorWidth = 40
        'muestra la columna de checkbox
        GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        AddHandler GridView1.SelectionChanged, AddressOf gridView1_SelectionChanged
        GridView1.OptionsSelection.MultiSelect = True
        'tamaño de la columna 
        GridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 25

        'creo la columna que sirve como contador de filas que hay en el grid
        'GridView1.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.Integer
        'AddHandler GridView1.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
        'GridView1.Columns.Item("#").VisibleIndex = 0

        'sirve para estilo de auto acomodo de tamaño de columnas
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.OptionsView.BestFitMaxRowCount = -1
        GridView1.BestFitColumns()

        'se crea la columna desde devexpress
        'Dim col As GridColumn = New GridColumn()
        'col.Caption = "P. Calculado Nuevo"
        'col.FieldName = "P. Calculado Nuevo"
        'col.UnboundType = UnboundColumnType.Decimal

        'con esta linea se hacen los redondeos desde el grid, es sobre la columna que se crea arriba
        'col.UnboundExpression = "(Round((([P. Base Guardado]*(1+[IXP]/100)) / [Paridad Pesos])))"

        'GridView1.Columns("P. Calculado Nuevo").VisibleIndex = 15

        'es para cuando se agrupa la columna en la parte de arriba
        Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        item.SummaryType = DevExpress.Data.SummaryItemType.Count
        item.DisplayFormat = "Total: {0}"
        'item.FieldName = "Cliente"
        'se valida que ya exista, ya que si existe se sigue creando el item
        If GridView1.GroupSummary.Count > 0 Then

        Else
            GridView1.GroupSummary.Add(item)
        End If

        'es para que haga las busquedas en la columna por todo lo que contiene
        GridView1.Columns("Cliente").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("Descripción").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("IXP").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("Marca SAY").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("Colección SAY").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("Modelo SAY").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("Modelo SICY").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("Talla").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("Piel").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("Color").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("P. Base Guardado").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("P. Calculado").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("P. Final").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("P. Base Actual").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("P. Calculado Nuevo").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("*P. Final Nuevo").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        GridView1.Columns("Paridad P. Base").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains


        'habilita si se van a editar o no los valores de la columna con el nombre que tiene
        'GridView1.Columns("#").OptionsColumn.AllowEdit = False
        GridView1.Columns("idCliente").OptionsColumn.AllowEdit = False
        GridView1.Columns("Cliente").OptionsColumn.AllowEdit = False
        GridView1.Columns("Descripción").OptionsColumn.AllowEdit = False
        GridView1.Columns("IXP").OptionsColumn.AllowEdit = False
        GridView1.Columns("Marca SAY").OptionsColumn.AllowEdit = False
        GridView1.Columns("Colección SAY").OptionsColumn.AllowEdit = False
        GridView1.Columns("Modelo SAY").OptionsColumn.AllowEdit = False
        GridView1.Columns("Modelo SICY").OptionsColumn.AllowEdit = False
        GridView1.Columns("Talla").OptionsColumn.AllowEdit = False
        GridView1.Columns("Piel").OptionsColumn.AllowEdit = False
        GridView1.Columns("Color").OptionsColumn.AllowEdit = False
        GridView1.Columns("P. Base Guardado").OptionsColumn.AllowEdit = False
        GridView1.Columns("P. Calculado").OptionsColumn.AllowEdit = False
        GridView1.Columns("P. Final").OptionsColumn.AllowEdit = False
        GridView1.Columns("P. Base Actual").OptionsColumn.AllowEdit = False
        GridView1.Columns("P. Calculado Nuevo").OptionsColumn.AllowEdit = False
        GridView1.Columns("*P. Final Nuevo").OptionsColumn.AllowEdit = True
        AddHandler GridView1.Click, AddressOf GridView1_ColumnClick
        GridView1.Columns("Paridad P. Base").OptionsColumn.AllowEdit = False
        GridView1.Columns("Id Lista Precio Cliente Producto").OptionsColumn.AllowEdit = False

        ' acomodo los header de las columnas de forma centrada
        GridView1.Columns("Cliente").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("Descripción").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("IXP").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("Marca SAY").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("Colección SAY").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("Modelo SICY").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("Talla").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("Piel").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("Color").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("P. Base Guardado").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("P. Calculado").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("P. Final").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("P. Base Actual").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("P. Calculado Nuevo").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("*P. Final Nuevo").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns("Paridad P. Base").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

        'GridView1.Columns("Paridad P. Base").AppearanceCell.TextOptions.HAlignment=
        'coolumna que guarda el valor de la paridad según la moneda que se le maneje a cada cliente
        GridView1.Columns("idCliente").Visible = False
        GridView1.Columns("Paridad Pesos").Visible = False
        GridView1.Columns("Id Lista Precio Cliente Producto").Visible = False

        'establece el tipo de valor que tiene la columna y el número de decimales que va mostrar ({0:N2}) (2 decimales)
        Dim displayFormatlstPrBGua = GridView1.Columns("P. Base Guardado").DisplayFormat
        displayFormatlstPrBGua.FormatType = FormatType.Numeric
        displayFormatlstPrBGua.FormatString = "{0:N2}"
        Dim displayFormatlstPrBCal = GridView1.Columns("P. Calculado").DisplayFormat
        displayFormatlstPrBCal.FormatType = FormatType.Numeric
        displayFormatlstPrBCal.FormatString = "{0:N2}"
        Dim displayFormatlstPre = GridView1.Columns("P. Final").DisplayFormat
        displayFormatlstPre.FormatType = FormatType.Numeric
        displayFormatlstPre.FormatString = "{0:N2}"
        Dim displayFormatlstPrBAct = GridView1.Columns("P. Base Actual").DisplayFormat
        displayFormatlstPrBAct.FormatType = FormatType.Numeric
        displayFormatlstPrBAct.FormatString = "{0:N2}"
        Dim displayFormatlstPrCNue = GridView1.Columns("P. Calculado Nuevo").DisplayFormat
        displayFormatlstPrCNue.FormatType = FormatType.Numeric
        displayFormatlstPrCNue.FormatString = "{0:N2}"
        Dim displayFormatPrFNue = GridView1.Columns("*P. Final Nuevo").DisplayFormat
        displayFormatPrFNue.FormatType = FormatType.Numeric
        displayFormatPrFNue.FormatString = "{0:N2}"
        Dim displayFormatlstPrPPreC = GridView1.Columns("Paridad P. Base").DisplayFormat
        displayFormatlstPrPPreC.FormatType = FormatType.Numeric
        displayFormatlstPrPPreC.FormatString = "{0:N2}"

        'sirve para cambiar el color de los encabezados de las columnas
        'GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        'GridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D

        'GridView1.Appearance.HeaderPanel.Options.UseBackColor = True
        'GridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.BurlyWood  
        For i As Integer = 1 To GridView1.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                GridView1.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                GridView1.OptionsView.EnableAppearanceEvenRow = True
                GridView1.Invalidate()
            End If
        Next
    End Sub

    'era para validar la igualdad entre dos campos no funciona
    'Private Sub GridView1_RowDataBound(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs)

    '    If e.Row("P. Calculado Nuevo") = e.Row("P. Final") Then
    '        MsgBox(e.Row("P. Calculado Nuevo"))
    '        e.Row.Visible = False

    '    End If
    'End Sub

    'Private Sub gridView1_CustomRowFilter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs)

    '    Dim View As GridView = sender
    '    Dim dv As DataView = View.DataSource
    '    If CDbl(dv(e.ListSourceRow)("P. Calculado Nuevo")) = CDbl(dv(e.ListSourceRow)("P. Final")) Then
    '        e.Visible = False
    '        e.Handled = True
    '    End If

    'End Sub

    Private Sub GridView1_ColumnClick(sender As Object, e As EventArgs) Handles GridView1.Click

       

    End Sub

    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        'realiza un contador de filas arrojadas
        If e.Column.FieldName = "#" AndAlso e.IsGetData Then
            e.Value = GridView1.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If

        'sirve para validar que sólo se puedan ingresar números en la columna que se le da dicha configuración
        If GridView1.RowCount > 0 Then
            Dim edit As New RepositoryItemTextEdit()
            edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            edit.Mask.EditMask = "n2"

            ' GridView1.Columns("P. Final Nuevo").ColumnEdit = edit.Mask.EditMask = "n2"
            'doy el nombre de columna que quiero que tenga dicha configuración
            GridView1.Columns("*P. Final Nuevo").ColumnEdit = edit
            
        End If
    End Sub

    Private Sub gridView1_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs)
        'sirve para tomar el número de clientes seleccionados
        For I = 0 To GridView1.SelectedRowsCount() - 1
            If (GridView1.GetSelectedRows()(I) >= 0) Then
                Rows.Add(GridView1.GetDataRow(GridView1.GetSelectedRows()(I)))
            End If
        Next
        'estalbezco en el label el número de clientes que se han seleccionado
        lblRegistros.Text = Rows.Count.ToString
        'limpio el arreglo ya que se ejecuta cada vez que se presiona y si no se limpia genera mas registros,
        'se tiene que estar limpiando cada que se selecciona un cliente. al final hace un conteo de los que están
        'seleccionados no importa que se esté limpiando cada vez que se selecciona/deselecciona un cliente
        Rows.Clear()
    End Sub


End Class