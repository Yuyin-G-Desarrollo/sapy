Imports Produccion.Negocios
Imports Entidades
Imports Infragistics.Win.UltraWinGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports DevExpress.XtraGrid
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting

Public Class MetasProduccionForm
    'Declaraciones globales
    Dim objUsuarioSesion As Usuarios
    Dim Editable As Boolean = False
    'Dim esPlantilla As Integer = 0

    Private Sub MetasProduccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializar()
        vwReporte.OptionsSelection.MultiSelect = True
        btnGuardar.Visible = False
        lblGuardar.Visible = False
    End Sub

    Public Sub inicializar()
        objUsuarioSesion = SesionUsuario.UsuarioSesion
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, objUsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        'Dependera de 2 cosas para el alta de una meta, si el valor de la variable esPlantilla = 0 sera el insert normal
        'si el valor es 1 entonces el insert sera de la plantilla
        Dim AltaMetas As New AltasYCambiosForm
        If vwReporte.RowCount > 1 Then
            AltaMetas.FormTipoAccion = "Alta"
            'If esPlantilla = 0 Then 'Valor determinante
            AltaMetas.formNaveId = cmbNave.SelectedValue
            'Else
            '    Dim posicionTabla As Integer = vwReporte.GetFocusedDataSourceRowIndex()
            '    Dim tablaDatos As DataTable
            '    tablaDatos = grdMetasProd.DataSource

            '    For i As Integer = 0 To tablaDatos.Rows.Count - 1
            '        If tablaDatos.Rows.Count > 0 And i = posicionTabla Then
            '            AltaMetas.formIdConfiguracion = tablaDatos.Rows(i).Item("IdConfiguracion")
            '            AltaMetas.FormDepartamento = tablaDatos.Rows(i).Item("Departamento")
            '            AltaMetas.FormDia = tablaDatos.Rows(i).Item("DiaLetra")
            '        End If
            '    Next
            'End If
            'AltaMetas.FormEsPlantilla = esPlantilla
            AltaMetas.formtablaDatos = grdMetasProd.DataSource
            AltaMetas.ShowDialog()
        End If
        ActualizarTablaMetas()
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        Dim objBu As New MetasProduccionBU
        Dim tablaDatos As New DataTable
        Dim IdNave As Integer
        grdMetasProd.DataSource = Nothing
        Try
            If cmbNave.SelectedIndex > 0 Then
                IdNave = cmbNave.SelectedValue
                Cursor = Cursors.WaitCursor

                tablaDatos = objBu.TraerDatosComboNave(IdNave)

                If tablaDatos.Rows.Count > 0 Then
                    'Se llena de acuerdo a la nave de producción seleccionada
                    grdMetasProd.DataSource = tablaDatos
                    Editable = False
                    DiseñoGrid()
                    'esPlantilla = 0
                    btnAlta.Enabled = True
                    btnEditar.Enabled = True
                    btnEstatusAnterior.Enabled = True
                    btnGuardar.Visible = False
                    lblGuardar.Visible = False
                Else
                    'Se llena la plantilla pre-definida, esto aplica cuando no hay datos en las naves de produccion o se creo una nueva nave de producción 
                    grdMetasProd.DataSource = PlantillaMetasPorNave()
                    If vwReporte.RowCount > 0 Then
                        Editable = True
                        DiseñoGrid()
                        'esPlantilla = 1
                        btnAlta.Enabled = False
                        btnEditar.Enabled = False
                        btnEstatusAnterior.Enabled = False
                        btnGuardar.Visible = True
                        lblGuardar.Visible = True
                    End If
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message())
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub DiseñoGrid()
        vwReporte.OptionsView.ColumnAutoWidth = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        vwReporte.Columns.ColumnByFieldName("IdConfiguracion").Visible = False
        vwReporte.Columns.ColumnByFieldName("IdMetaProduccion").Visible = False
        vwReporte.Columns.ColumnByFieldName("Departamento").Caption = "Departamento"
        vwReporte.Columns.ColumnByFieldName("DiaLetra").Caption = "Dia"
        vwReporte.Columns.ColumnByFieldName("Cantidad").Caption = "Cantidad"

        vwReporte.Columns.ColumnByFieldName("Departamento").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("DiaLetra").OptionsColumn.AllowEdit = False

        If Editable = True Then
            vwReporte.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = True
        Else
            vwReporte.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnEstatusAnterior_Click(sender As Object, e As EventArgs) Handles btnEstatusAnterior.Click
        Dim metasHora As New MetasHoraForm
        Dim mensajeAdvertencia As New AdvertenciaForm
        Dim Cantidad As Integer
        If vwReporte.RowCount > 1 Then

            Dim posicionTabla As Integer = vwReporte.GetFocusedDataSourceRowIndex()
            Dim tablaDatos As DataTable
            tablaDatos = grdMetasProd.DataSource

            For i As Integer = 0 To tablaDatos.Rows.Count - 1
                If tablaDatos.Rows.Count > 0 And i = posicionTabla Then
                    metasHora.formIdMetaProduccion = tablaDatos.Rows(i).Item("IdMetaProduccion")
                    metasHora.FormDepartamento = tablaDatos.Rows(i).Item("Departamento")
                    metasHora.FormDia = tablaDatos.Rows(i).Item("DiaLetra")
                    Cantidad = tablaDatos.Rows(i).Item("Cantidad")
                End If
            Next
            If Cantidad = 0 Then
                mensajeAdvertencia.mensaje = "La meta del día " + metasHora.FormDia.ToLower() + " esta en 0."
                mensajeAdvertencia.ShowDialog()
            Else
                metasHora.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim Modificar As New AltasYCambiosForm
        If vwReporte.RowCount > 1 Then

            Dim posicionTabla As Integer = vwReporte.GetFocusedDataSourceRowIndex()
            Dim tablaDatos As DataTable
            tablaDatos = grdMetasProd.DataSource

            For i As Integer = 0 To tablaDatos.Rows.Count - 1
                If tablaDatos.Rows.Count > 0 And i = posicionTabla Then
                    Modificar.formIdMetaProduccion = tablaDatos.Rows(i).Item("IdMetaProduccion")
                    Modificar.FormDepartamento = tablaDatos.Rows(i).Item("Departamento")
                    Modificar.FormDia = tablaDatos.Rows(i).Item("DiaLetra")
                    Modificar.FormPares = tablaDatos.Rows(i).Item("Cantidad")
                End If
            Next

            Modificar.FormTipoAccion = "Editar"
            Modificar.ShowDialog()
        End If
        ActualizarTablaMetas()
    End Sub

    Public Function PlantillaMetasPorNave()
        Dim objBU As New MetasProduccionBU
        Dim tbaDepartamentos As DataTable
        Dim tbaCamposPlantilla As New DataTable
        Dim mensajeAdvertencia As New AdvertenciaForm
        Dim IdNave As Integer

        IdNave = cmbNave.SelectedValue
        tbaDepartamentos = objBU.TraerDepartamentos(IdNave)

        If tbaDepartamentos.Rows.Count > 0 Then

            Dim arrDepartamentos() As String = {"CORTE", "PESPUNTE", "MONTADO Y ADORNO"}
            Dim arrDiasSemana() As String = {"LUNES", "MARTES", "MIERCOLES", "JUEVES", "VIERNES", "SABADO"}


            tbaCamposPlantilla.Columns.Add("IdConfiguracion")
            tbaCamposPlantilla.Columns.Add("IdMetaProduccion")
            tbaCamposPlantilla.Columns.Add("Departamento")
            tbaCamposPlantilla.Columns.Add("DiaLetra")
            tbaCamposPlantilla.Columns.Add("Cantidad")

            For i As Integer = 0 To arrDepartamentos.Length - 1
                For j As Integer = 0 To arrDiasSemana.Length - 1
                    If arrDiasSemana(i).ToString() <> "" Then
                        tbaCamposPlantilla.Rows.Add(New Object() {0, 0, arrDepartamentos(i).ToString(), arrDiasSemana(j).ToString(), 0})
                    End If
                Next
            Next

            'Se agrego para asignar el iddepartamento cuando aun no tiene metas agregadas pero si departamentos designados
            For i As Integer = 0 To tbaDepartamentos.Rows.Count - 1
                For j As Integer = 0 To tbaCamposPlantilla.Rows.Count - 1
                    If tbaDepartamentos.Rows(i).Item("Departamento").ToString() = tbaCamposPlantilla.Rows(j).Item("Departamento").ToString() Then
                        tbaCamposPlantilla.Rows(j).Item("IdConfiguracion") = tbaDepartamentos.Rows(i).Item("IdConfiguracion")
                    End If
                Next
            Next

        Else
            mensajeAdvertencia.mensaje = "La nave seleccionada no cuenta con departamentos asignados."
            mensajeAdvertencia.ShowDialog()
        End If
        'For Each row As DataRow In tbaCamposPlantilla.Rows
        '    row.Item("IdConfiguracion").ToString()
        '    row.Item("IdMetaProduccion").ToString()
        '    row.Item("Departamento").ToString()
        '    row.Item("DiaLetra").ToString()
        'Next

        Return tbaCamposPlantilla
    End Function

    Public Sub ActualizarTablaMetas()
        Dim objBu As New MetasProduccionBU
        Dim tablaDatos As New DataTable
        Dim IdNave As Integer
        grdMetasProd.DataSource = Nothing
        Try
            If cmbNave.SelectedIndex > 0 Then
                IdNave = cmbNave.SelectedValue
                Cursor = Cursors.WaitCursor
                tablaDatos = objBu.TraerDatosComboNave(IdNave)
                If tablaDatos.Rows.Count > 0 Then
                    grdMetasProd.DataSource = tablaDatos
                    DiseñoGrid()
                    btnAlta.Enabled = True
                    btnEditar.Enabled = True
                    btnEstatusAnterior.Enabled = True
                    btnGuardar.Visible = False
                    lblGuardar.Visible = False
                    Editable = False
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message())
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim tablaDeDatos As DataTable
        Dim objBU As New MetasProduccionBU
        Dim confirmarInsert As New ConfirmarForm

        Dim tipoInsert As String
        tipoInsert = "Alta"

        tablaDeDatos = grdMetasProd.DataSource

        confirmarInsert.mensaje = "¿Está seguro de guardar la información?"

        If confirmarInsert.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                For i As Integer = 0 To tablaDeDatos.Rows.Count - 1
                    objBU.AgregarNuevaOActualizarMeta(tipoInsert, tablaDeDatos.Rows(i).Item("Cantidad"), ObtenerDia(tablaDeDatos.Rows(i).Item("DiaLetra")), tablaDeDatos.Rows(i).Item("IdConfiguracion"), 0)
                Next
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End If
        ActualizarTablaMetas()
    End Sub

    Private Sub MetasProduccionForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim confirmar As New ConfirmarForm

        confirmar.mensaje = "Los datos no guardados se borrarán, ¿Desea continuar?"

        If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            grdMetasProd.DataSource = Nothing
            Editable = False
        Else
            e.Cancel = True
        End If

    End Sub

    Public Function ObtenerDia(ByVal Dia As String)
        Dim ValorDia As Integer = 0

        Select Case Dia
            Case "LUNES"
                ValorDia = 1
            Case "MARTES"
                ValorDia = 2
            Case "MIERCOLES"
                ValorDia = 3
            Case "JUEVES"
                ValorDia = 4
            Case "VIERNES"
                ValorDia = 5
            Case "SABADO"
                ValorDia = 6
            Case "DOMINGO"
                ValorDia = 7
            Case Else
                ValorDia = 0
        End Select

        Return ValorDia
    End Function
End Class