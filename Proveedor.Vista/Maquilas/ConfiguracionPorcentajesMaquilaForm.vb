Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Base
Imports Proveedores.BU
Imports Tools
Imports Entidades
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Drawing
Imports DevExpress.XtraGrid
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Columns


Public Class ConfiguracionPorcentajesMaquilaForm
    Private confirmacion As Boolean = False
    Private RegistroEdicion As Integer
    Private lstModificados As List(Of String) = New List(Of String) 'se utiliza para pintar el registro modificado en el gridview

    Private Sub ConfiguracionPorcentajesMaquilaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarConfiguracionMaquilas()
    End Sub
    ''' <summary>
    ''' Carga las naves con los procentajes correspondientes en el gridview 
    ''' </summary>
    Private Sub CargarConfiguracionMaquilas()
        Dim ObjConfiguracion As New ConfiguracionPorcentajeMaquilasBU
        Dim lstConfiguracion As New DataTable
        lstConfiguracion = ObjConfiguracion.ObtenerConfiguracionesPorcentajesMaquila()
        If lstConfiguracion.Rows.Count = 0 Then
            gdvDatosConfiguracionPorcentajeMaquilas.DataSource = Nothing
            vwDatosConfiguracionPorcentajeMaquilas.Columns.Clear()
        Else
            gdvDatosConfiguracionPorcentajeMaquilas.DataSource = lstConfiguracion
            Dim numeroSemanas As Int32 = Convert.ToInt32(DateTime.Now.DayOfYear / 7)
            lblNumeroSemana.Text = numeroSemanas
            lblNumeroSemana.Visible = True
            diseñoGridView()
        End If
    End Sub
    Private Sub diseñoGridView()
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Tools.DiseñoGrid.AlternarColorEnFilas(vwDatosConfiguracionPorcentajeMaquilas)
        vwDatosConfiguracionPorcentajeMaquilas.Bands.Clear() '' limpia las columnas del band del gridview
        vwDatosConfiguracionPorcentajeMaquilas.Appearance.HeaderPanel.Options.UseBackColor = True
        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = Nothing
        vwDatosConfiguracionPorcentajeMaquilas.Columns.AddField("idnave")
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("idnave").OwnerBand = band
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("idnave").Visible = False
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("idnave").Caption = "id nave"

        vwDatosConfiguracionPorcentajeMaquilas.Columns.AddField("nave")
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("nave").OwnerBand = band
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("nave").Visible = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("nave").Caption = "NAVE"
        vwDatosConfiguracionPorcentajeMaquilas.Columns("nave").Width = 75
        vwDatosConfiguracionPorcentajeMaquilas.Columns("nave").OptionsColumn.FixedWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.OptionsView.ColumnAutoWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("nave").OptionsColumn.AllowEdit = False

        vwDatosConfiguracionPorcentajeMaquilas.Columns.AddField("grupo")
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("grupo").OwnerBand = band
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("grupo").Visible = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("grupo").Caption = "GRUPO"
        vwDatosConfiguracionPorcentajeMaquilas.Columns("grupo").Width = 48
        vwDatosConfiguracionPorcentajeMaquilas.Columns("grupo").OptionsColumn.FixedWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.OptionsView.ColumnAutoWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("grupo").OptionsColumn.AllowEdit = False

        vwDatosConfiguracionPorcentajeMaquilas.Columns.AddField("activo")
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("activo").OwnerBand = band
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("activo").Visible = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("activo").Caption = "ACTIVO"
        vwDatosConfiguracionPorcentajeMaquilas.Columns("activo").Width = 48
        vwDatosConfiguracionPorcentajeMaquilas.Columns("activo").OptionsColumn.FixedWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.OptionsView.ColumnAutoWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("activo").OptionsColumn.AllowEdit = False

        vwDatosConfiguracionPorcentajeMaquilas.Columns.AddField("isr")
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("isr").OwnerBand = band
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("isr").Visible = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("isr").Caption = "ISR"
        vwDatosConfiguracionPorcentajeMaquilas.Columns("isr").Width = 47
        vwDatosConfiguracionPorcentajeMaquilas.Columns("isr").OptionsColumn.FixedWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.OptionsView.ColumnAutoWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("isr").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("isr").DisplayFormat.FormatString = "{0:0}%"

        vwDatosConfiguracionPorcentajeMaquilas.Columns.AddField("herramental")
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("herramental").OwnerBand = band
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("herramental").Visible = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("herramental").Caption = "D&D Y HERRAMENTAL"
        vwDatosConfiguracionPorcentajeMaquilas.Columns("herramental").Width = 120
        vwDatosConfiguracionPorcentajeMaquilas.Columns("herramental").OptionsColumn.FixedWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.OptionsView.ColumnAutoWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("herramental").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("herramental").DisplayFormat.FormatString = "{0:0}%"

        vwDatosConfiguracionPorcentajeMaquilas.Columns.AddField("financiamiento")
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("financiamiento").OwnerBand = band
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("financiamiento").Visible = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("financiamiento").Caption = "FINANCIAMIENTO RIESGO"
        vwDatosConfiguracionPorcentajeMaquilas.Columns("financiamiento").Width = 147
        vwDatosConfiguracionPorcentajeMaquilas.Columns("financiamiento").OptionsColumn.FixedWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.OptionsView.ColumnAutoWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("financiamiento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("financiamiento").DisplayFormat.FormatString = "{0:0}%"

        vwDatosConfiguracionPorcentajeMaquilas.Bands.Add(band)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = "UTILIDAD NETA"
        vwDatosConfiguracionPorcentajeMaquilas.Columns.AddField("fábrica")
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("fábrica").OwnerBand = band
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("fábrica").Visible = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("fábrica").OptionsColumn.AllowEdit = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("fábrica").Caption = "FÁBRICA"
        vwDatosConfiguracionPorcentajeMaquilas.Columns("fábrica").Width = 60
        vwDatosConfiguracionPorcentajeMaquilas.Columns("fábrica").OptionsColumn.FixedWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.OptionsView.ColumnAutoWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("fábrica").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("fábrica").DisplayFormat.FormatString = "{0:0}%"

        vwDatosConfiguracionPorcentajeMaquilas.Columns.AddField("administracion")
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("administracion").OwnerBand = band
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("administracion").Visible = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("administracion").OptionsColumn.AllowEdit = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("administracion").Caption = "ADMINISTRACIÓN"
        vwDatosConfiguracionPorcentajeMaquilas.Columns("administracion").Width = 120
        vwDatosConfiguracionPorcentajeMaquilas.Columns("administracion").OptionsColumn.FixedWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.OptionsView.ColumnAutoWidth = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("administracion").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("administracion").DisplayFormat.FormatString = "{0:0}%"

        vwDatosConfiguracionPorcentajeMaquilas.Columns.AddField("comercial")
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("comercial").OwnerBand = band
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("comercial").Visible = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("comercial").OptionsColumn.AllowEdit = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("comercial").Caption = "COMERCIAL"
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("comercial").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("comercial").DisplayFormat.FormatString = "{0:0}%"

        vwDatosConfiguracionPorcentajeMaquilas.Columns.AddField("editado")
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("editado").OwnerBand = band
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("editado").Visible = False
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("editado").OptionsColumn.AllowEdit = True
        vwDatosConfiguracionPorcentajeMaquilas.Columns.ColumnByFieldName("editado").Caption = "EDITADO"

        vwDatosConfiguracionPorcentajeMaquilas.Bands.Add(band)
        ''CENTRA LOS BANDS
        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In vwDatosConfiguracionPorcentajeMaquilas.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            gridband.OptionsBand.AllowMove = False
            For Each childrenBand In gridband.Children
                childrenBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Next
        Next

        'CENTRA LOS ENCABEZADOS DE LAS COLUMNAS
        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In vwDatosConfiguracionPorcentajeMaquilas.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next

        vwDatosConfiguracionPorcentajeMaquilas.IndicatorWidth = 40 ''TAMAÑO DEL INDICADOR

    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If RegistroEdicion = 0 Then
            Me.Close()
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Todos los cambios no guardados se perderan ¿desea continuar?."
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                confirmacion = True
                Me.Close()
            End If
        End If
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim correcto As New Tools.ExitoForm
        If RegistroEdicion = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay datos para guardar.")
        Else
            EditarPorcentajesMaquila()
            If RegistroEdicion = 0 Then
                correcto.mensaje = "Porcentajes Editados Correctamente"
                correcto.ShowDialog()
                CargarConfiguracionMaquilas()
            End If
        End If
    End Sub
    ''' <summary>
    ''' proceso que edita valores de una o varias filas dentro de un gridview, cuando el usuario selecciona el boton de guardar
    ''' </summary>
    Private Sub EditarPorcentajesMaquila()
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim objConfigPorcentajesMaquila As New ConfiguracionPorcentajeMaquilasBU
        Dim EntidadesPorcentajeMaquila As New Entidades.ConfiguracionPorcentajesMaquilas
        Dim conta As Integer
        Dim msgResult As String = Nothing
        objMensajeConf.mensaje = "¿Desea guardar los cambios?"
        If objMensajeConf.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            For conta = 0 To vwDatosConfiguracionPorcentajeMaquilas.RowCount
                EntidadesPorcentajeMaquila.cpmEditado = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.GetVisibleRowHandle(conta), "editado")
                If EntidadesPorcentajeMaquila.cpmEditado = True Then
                    EntidadesPorcentajeMaquila.cpmIdnave = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.GetVisibleRowHandle(conta), "idnave")
                    EntidadesPorcentajeMaquila.cpmIsr = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.GetVisibleRowHandle(conta), "isr")
                    EntidadesPorcentajeMaquila.cpmHerramientas = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.GetVisibleRowHandle(conta), "herramental")
                    EntidadesPorcentajeMaquila.cpmFinanciamiento = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.GetVisibleRowHandle(conta), "financiamiento")
                    EntidadesPorcentajeMaquila.cpmFabrica = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.GetVisibleRowHandle(conta), "fábrica")
                    EntidadesPorcentajeMaquila.cpmAdministracion = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.GetVisibleRowHandle(conta), "administracion")
                    EntidadesPorcentajeMaquila.cpmComercial = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.GetVisibleRowHandle(conta), "comercial")
                    EntidadesPorcentajeMaquila.cpmEditado = 1
                    EntidadesPorcentajeMaquila.cpmMsgResult = objConfigPorcentajesMaquila.EditaPorcentajesMaquila(EntidadesPorcentajeMaquila)
                    If EntidadesPorcentajeMaquila.cpmMsgResult <> "Registros Actualizados" Then ''Diferente a palabra, no sigue con el ciclo FOR
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al guardar los datos. " & Environment.NewLine & EntidadesPorcentajeMaquila.cpmMsgResult)
                        Exit For
                    End If
                End If
            Next conta
            RegistroEdicion = 0 'si todo sale bien'
        End If
    End Sub
    ''' <summary>
    ''' detecta el cambio de un valor de una celda en el gridview
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub vwDatosConfiguracionPorcentajeMaquilas_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles vwDatosConfiguracionPorcentajeMaquilas.CellValueChanged
        If e.Column.FieldName = "herramental" OrElse e.Column.FieldName = "financiamiento" OrElse e.Column.FieldName = "fábrica" OrElse e.Column.FieldName = "administracion" OrElse e.Column.FieldName = "comercial" Then
            Try
                vwDatosConfiguracionPorcentajeMaquilas.SetRowCellValue(e.RowHandle, "editado", True)
                If lstModificados.Contains(e.RowHandle.ToString & "," & e.Column.VisibleIndex) = False Then
                    lstModificados.Add(e.RowHandle.ToString & "," & e.Column.VisibleIndex)
                End If
                RegistroEdicion += 1
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
            End Try
        End If
    End Sub
    Private Sub vwDatosConfiguracionPorcentajeMaquilas_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles vwDatosConfiguracionPorcentajeMaquilas.RowCellStyle
        If lstModificados.Contains(e.RowHandle.ToString & "," & e.Column.VisibleIndex) = True Then
            e.Appearance.ForeColor = Label1.ForeColor
            e.Appearance.FontStyleDelta = FontStyle.Bold
        End If
    End Sub
    Private Sub ConfiguracionPorcentajesMaquilaForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If RegistroEdicion = 0 Then

        Else
            If confirmacion = True Then

            Else
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "Todos los cambios no guardados se perderan ¿desea continuar?."
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then

                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        LimpiaInformacionGridview()
    End Sub
    ''' <summary>
    ''' EN LUGAR DE LIMPIAR EL GRIDVIEW, VUELVE A REFRESCAR LA INFORMACION
    ''' </summary>
    Private Sub LimpiaInformacionGridview()
        If RegistroEdicion = 0 Then 'NO hay registros en edicion
            gdvDatosConfiguracionPorcentajeMaquilas.DataSource = Nothing
            vwDatosConfiguracionPorcentajeMaquilas.Columns.Clear()
            CargarConfiguracionMaquilas() 'vuelve a cargar los valores 
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Todos los cambios no guardados se perderan ¿desea continuar?."
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                confirmacion = True
                CargarConfiguracionMaquilas()
                RegistroEdicion = 0
            End If
        End If
    End Sub
    ''' <summary>
    ''' INDICA EL NUMERO DE COLUMNAS QUE CONTIENE UN GRIDVIEW (1,2,3 ETC...)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub vwDatosConfiguracionPorcentajeMaquilas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwDatosConfiguracionPorcentajeMaquilas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    ''' <summary>
    ''' gridview NO ACEPTA valores mayores a 100 (101,102,103, etc....) y menores a 0 (-1,-2,-3, etc...), ni letras, valida que los campos fabrica,administracion y comercial NO REBASEN EL 100%
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub vwDatosConfiguracionPorcentajeMaquilas_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles vwDatosConfiguracionPorcentajeMaquilas.ValidatingEditor
        If vwDatosConfiguracionPorcentajeMaquilas.FocusedRowHandle >= 0 Then
            If Not IsDBNull(e.Value) AndAlso e.Value.ToString.Trim = "" Then
                Dim view As ColumnView = sender
                Dim column As GridColumn = If(TryCast(e, EditFormValidateEditorEventArgs)?.Column, view.FocusedColumn)

                e.Valid = False
            ElseIf IsNumeric(e.Value) Then
                If vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName = "isr" Or vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName = "herramental" Or vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName = "financiamiento" Then
                    If e.Value > 100 Or e.Value < 0 Then
                        e.Valid = False
                    End If
                ElseIf vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName = "fábrica" Or vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName = "administracion" Or vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName = "comercial" Then
                    Dim totalfabrica As Int32 = 0
                    Dim totaladministracion As Int32 = 0
                    Dim totalcomercial As Int32 = 0

                    Select Case vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName
                        Case "fábrica"
                            totalfabrica = e.Value
                            totaladministracion = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.FocusedRowHandle, "administracion")
                            totalcomercial = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.FocusedRowHandle, "comercial")
                        Case "administracion"
                            totalfabrica = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.FocusedRowHandle, "fábrica")
                            totaladministracion = e.Value
                            totalcomercial = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.FocusedRowHandle, "comercial")
                        Case "comercial"
                            totalfabrica = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.FocusedRowHandle, "fábrica")
                            totaladministracion = vwDatosConfiguracionPorcentajeMaquilas.GetRowCellValue(vwDatosConfiguracionPorcentajeMaquilas.FocusedRowHandle, "administracion")
                            totalcomercial = e.Value
                    End Select

                    If totalfabrica + totaladministracion + totalcomercial > 100 Then ''calcula si los campos rebasan el 100%
                        e.Valid = False
                    End If
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' si el valor es mayor a 100 y menor a 0, manda mensaje y no deja avanzar al siguiente rango
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub vwDatosConfiguracionPorcentajeMaquilas_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles vwDatosConfiguracionPorcentajeMaquilas.InvalidValueException
        If vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName = "isr" Or vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName = "herramental" Or vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName = "financiamiento" Then
            e.ErrorText = "El valor ingresado debe ser numérico, no puede ser mayor a 100% y menor a 0%."
        ElseIf vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName = "fábrica" Or vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName = "administracion" Or vwDatosConfiguracionPorcentajeMaquilas.FocusedColumn.FieldName = "comercial" Then
            e.ErrorText = "El valor de la utlidad neta debe ser máximo 100%"
        End If
    End Sub
End Class