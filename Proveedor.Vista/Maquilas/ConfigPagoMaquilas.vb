Imports Tools
Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports System.Drawing

Public Class ConfigPagoMaquilas
    Dim adv As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim razonesSoc As New DataTable
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub
    Private Sub ConfigPagoMaquilas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Deshabilitar el botón de guardar para los que no lo tengan en sus permisos.
        If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConfigPagoMaquilas", "SAVE") Then
            btnGuardar.Enabled = False
            btnGuardar.Enabled = False
        End If

        llenarGrid()
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Public Sub llenarGrid()
        Dim obj As New ConfigPagoMaquilasBU
        Dim datos As New DataTable
        Dim configdatos As New DataTable
        razonesSoc = obj.getContribuyentes 'Datos de las razones sociales con sus id's
        datos = obj.getNavesConfig 'Configuración de las Naves, %Factura, %Remisión y $Tolerancia
        configdatos = obj.getConfigContribuyentes 'Configuración de los contribuyentes si estan activos para las diferentes Naves
        For Each row As DataRow In razonesSoc.Rows
            datos.Columns.Add(row("IDRazSoc"), Type.GetType("System.String")) 'Agregar la columna id de la razon social
            datos.Columns.Add(("" & row("IDRazSoc") & "-" & row("alias")), Type.GetType("System.Int32")) 'Agregar el nombre corto de la razon social
        Next
        For Each row As DataRow In razonesSoc.Rows
            For Each row2 As DataRow In datos.Rows
                row2(("" & row("IDRazSoc") & "-" & row("alias"))) = 0 'Inicializamos como Falso todas las razones sociales
            Next
        Next

        For Each row As DataRow In configdatos.Rows 'Datos de configuración de los contribuyentes
            For Each row2 As DataRow In datos.Rows 'Datos de las Naves y nuevas columnas de las Razones sociales
                If row2("idConfig") = row("cpm_id") Then 'Si el id de ConfigPagoMaquilas es igual al de ConfigPagoMaquilasDetalles buscará la columna para ingresar el valor correspondiente
                    For value As Integer = 0 To datos.Columns.Count - 1 'Buscamos columna a ingresar valor dependiendo de la razón social
                        If datos.Columns(value).ColumnName = row("cpmd_idRazSoc").ToString Then '(-_-)
                            row2(value + 1) = row("cpm_estatus") 'Al encontrar la columna establecemos el valor
                            Exit For
                        End If
                    Next
                Else
                End If
            Next
        Next
        grdConfig.DataSource = datos
        diseño()
    End Sub
    Public Sub diseño()
        Try
            With grdConfig.DisplayLayout.Bands(0)
                .Columns("IdNave").Hidden = True
                .Columns("idConfig").Hidden = True
                .Columns("naveConfigStatus").Hidden = True
                .Columns("razSocConfigStatus").Hidden = True
                For Each row As DataRow In razonesSoc.Rows 'Formato para las columnas Agregadas(Razones sociales)
                    Dim x As String
                    Dim x2 As String
                    x2 = (row("IDRazSoc") & "-" & row("alias"))
                    x = row("IDRazSoc")
                    .Columns(x).Hidden = True
                    .Columns(x2).Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                    .Columns(x2).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                    .Columns(x2).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                    .Columns(x2).AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                    .Columns(x2).Header.Caption = row("alias")
                Next
                .Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("% Remisión").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("% Factura").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("$ Tolerancia").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("% Remisión").Width = 75
                .Columns("% Factura").Width = 70
                .Columns("$ Tolerancia").Width = 80
            End With
            grdConfig.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdConfig.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            'grdListas.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
            'pintarceldas()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub pintarceldas()
        Try
            Dim conPrecio As Integer = 0
            Dim sinPrecio As Integer = 0
            Dim i As Integer = 0           
            Do
                For Each row As DataRow In razonesSoc.Rows
                    Dim x2 As String
                    x2 = (row("IDRazSoc") & "-" & row("alias"))
                    If CBool(grdConfig.Rows(i).Cells(x2).Value) = True Then
                        grdConfig.Rows(i).Cells(x2).Appearance.BackColor = Color.GreenYellow
                    End If
                Next 
                i += 1
            Loop While i < grdConfig.Rows.Count
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardar()
    End Sub
    Public Sub guardar()
        Dim obj As New ConfigPagoMaquilasBU
        Dim config As New DataTable
        Dim idConfig As New DataTable
        Dim idConf As Integer = 0
        Dim tmp As New DataTable
        Dim factura As Integer = 0
        Dim remision As Integer = 0
        Try
            Me.Cursor = Cursors.WaitCursor
            For Each row As UltraGridRow In grdConfig.Rows
                If row.Cells("idConfig").Value = 0 And row.Cells("naveConfigStatus").Value = 1 Then 'Identifica si tiene que insertar o actualizar la config de la Nave
                    'Insertar config de la nave
                    Try
                        factura = 0
                        remision = 0
                        factura = Convert.ToInt32(row.Cells("% Factura").Value)
                        remision = Convert.ToInt32(row.Cells("% Remisión").Value)
                        idConfig = obj.insertConfiguracion(row.Cells("idNave").Value, row.Cells("% Factura").Value, row.Cells("% Remisión").Value, row.Cells("$ Tolerancia").Value)
                    Catch ex As Exception
                        'Posiblemente al entrar aquí los valores del row fueron nulos
                        'Después de este punto no insertar ningún registro relacionado con está configuración de la nave
                    End Try
                    If idConfig.Rows.Count > 0 Then
                        idConf = idConfig.Rows(0).Item(0).ToString
                    End If
                ElseIf row.Cells("idConfig").Value > 0 And row.Cells("naveConfigStatus").Value = 1 Then
                    'Actualizar config de la nave
                    obj.updateConfiguracion(row.Cells("idConfig").Value, row.Cells("% Factura").Value, row.Cells("% Remisión").Value, row.Cells("$ Tolerancia").Value)
                End If
                If row.Cells("razSocConfigStatus").Value = 1 Then
                    For Each row2 As DataRow In razonesSoc.Rows
                        If CBool(row.Cells(("" & row2("IDRazSoc") & "-" & row2("alias"))).Value) Then 'Verifica si esta seleccionado el checkbox de alguna razón social
                            If row.Cells("idConfig").Value > 0 Or idConf > 0 Then
                                tmp = obj.existeConfiguracionDetalles(row.Cells("idConfig").Value, row2("IDRazSoc"))
                                If tmp.Rows.Count > 0 Then
                                    'Actualizar
                                    obj.updateConfiguracionDetalles(row.Cells("idConfig").Value, row2("IDRazSoc"), CBool(row.Cells(("" & row2("IDRazSoc") & "-" & row2("alias"))).Value))
                                Else
                                    'Insertar
                                    If idConf > 0 Then
                                        obj.insertConfiguracionDetalles(idConf, row2("IDRazSoc"), CBool(row.Cells(("" & row2("IDRazSoc") & "-" & row2("alias"))).Value))
                                    Else
                                        If row.Cells("idConfig").Value > 0 Then
                                            obj.insertConfiguracionDetalles(row.Cells("idConfig").Value, row2("IDRazSoc"), CBool(row.Cells(("" & row2("IDRazSoc") & "-" & row2("alias"))).Value))
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            If row.Cells("idConfig").Value > 0 Or idConf > 0 Then
                                tmp = obj.existeConfiguracionDetalles(row.Cells("idConfig").Value, row2("IDRazSoc"))
                                If tmp.Rows.Count > 0 Then
                                    'Actualizar
                                    obj.updateConfiguracionDetalles(row.Cells("idConfig").Value, row2("IDRazSoc"), CBool(row.Cells(("" & row2("IDRazSoc") & "-" & row2("alias"))).Value))
                                Else
                                    'Insertar
                                    If idConf > 0 Then
                                        obj.insertConfiguracionDetalles(idConf, row2("IDRazSoc"), CBool(row.Cells(("" & row2("IDRazSoc") & "-" & row2("alias"))).Value))
                                    Else
                                        If row.Cells("idConfig").Value > 0 Then
                                            obj.insertConfiguracionDetalles(row.Cells("idConfig").Value, row2("IDRazSoc"), CBool(row.Cells(("" & row2("IDRazSoc") & "-" & row2("alias"))).Value))
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            Next
            exito.mensaje = "Configuración guardada."
            exito.ShowDialog()
            llenarGrid()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió al inesperado Detalle: " & ex.Message
            adv.ShowDialog()
        End Try
    End Sub

    Private Sub grdConfig_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdConfig.AfterCellUpdate
        Try
            Dim factura As Integer = 0
            Dim remision As Integer = 0
            If grdConfig.Rows.Count > 0 Then
                If e.Cell.Column.ToString = "naveConfigStatus" Or e.Cell.Column.ToString = "idConfig" Or
                    e.Cell.Column.ToString = "IdNave" Or e.Cell.Column.ToString = "Nave" Or e.Cell.Column.ToString = "% Factura" Or
                    e.Cell.Column.ToString = "% Remisión" Or e.Cell.Column.ToString = "$ Tolerancia" Then
                    grdConfig.ActiveRow.Cells("naveConfigStatus").Value = 1
                    If e.Cell.Column.ToString = "% Remisión" Then
                        Try
                            remision = grdConfig.ActiveRow.Cells("% Remisión").Value
                        Catch ex As Exception
                            remision = 0
                        End Try
                        Try
                            factura = grdConfig.ActiveRow.Cells("% Factura").Value
                        Catch ex As Exception
                            factura = 0
                        End Try

                        If Not (remision + factura) = 100 Then
                            If remision < 0 Then
                                grdConfig.ActiveRow.Cells("% Remisión").Value = 0
                            ElseIf remision > 100 Then
                                grdConfig.ActiveRow.Cells("% Remisión").Value = 100
                            End If
                            grdConfig.ActiveRow.Cells("% Factura").Value = 100 - Convert.ToInt32(grdConfig.ActiveRow.Cells("% Remisión").Value)
                        End If

                    ElseIf e.Cell.Column.ToString = "% Factura" Then
                        Try
                            remision = grdConfig.ActiveRow.Cells("% Remisión").Value
                        Catch ex As Exception
                            remision = 0
                        End Try
                        Try
                            factura = grdConfig.ActiveRow.Cells("% Factura").Value
                        Catch ex As Exception
                            factura = 0
                        End Try
                        If Not (remision + factura) = 100 Then
                            If factura < 0 Then
                                grdConfig.ActiveRow.Cells("% Factura").Value = 0
                            ElseIf factura > 100 Then
                                grdConfig.ActiveRow.Cells("% Factura").Value = 100
                            End If
                            grdConfig.ActiveRow.Cells("% Remisión").Value = 100 - Convert.ToInt32(grdConfig.ActiveRow.Cells("% Factura").Value)
                        End If
                    End If
                Else
                    grdConfig.ActiveRow.Cells("razSocConfigStatus").Value = 1
                End If
            End If
        Catch ex As Exception
            adv.mensaje = ex.Message
            adv.ShowDialog()
        End Try
       
    End Sub

    Private Sub grdConfig_KeyDown(sender As Object, e As KeyEventArgs) Handles grdConfig.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Enter Then
                grdConfig.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdConfig.DisplayLayout.Bands(0)
                If grdConfig.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdConfig.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdConfig.ActiveCell = nextRow.Cells(grdConfig.ActiveCell.Column)
                    e.Handled = True
                    grdConfig.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdConfig_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdConfig.KeyPress
        If grdConfig.Rows.Count > 0 Then
            Try
                If Not grdConfig.ActiveCell.IsFilterRowCell Then
                    If Char.IsDigit(e.KeyChar) Then
                        e.Handled = False
                    ElseIf Char.IsControl(e.KeyChar) Then
                        e.Handled = False
                    ElseIf e.KeyChar = "." Then
                        e.Handled = True
                    ElseIf e.KeyChar = "." Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grdConfig_Error(sender As Object, e As ErrorEventArgs) Handles grdConfig.Error
        If e.ErrorText.Contains("Unable to update the data value: No se puede obtener acceso al objeto desechado.") Then
            e.Cancel = True
        End If
    End Sub
End Class