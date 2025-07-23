Imports Produccion.Negocios
Imports Tools

Public Class MetasHoraForm
    Dim Editable As Boolean = False

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim metasHora As New AltaCambiosMetasHoraForm
        metasHora.formTipoAccion = "Alta"
        metasHora.formIdMetaProduccionMT = formIdMetaProduccion
        metasHora.ShowDialog()
        llenarTablaMetasPorHora()
    End Sub

    Private Sub MetasHoraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDep.Text = FormDepartamento
        lblDiaSemana.Text = FormDia
        'If formIdMetaProduccion > 0 Then
        llenarTablaMetasPorHora()
        'Else
        '    'Plantilla para metas hora
        '    plantillaMetasHora()
        'End If
    End Sub

    Dim IdMetaProduccion As Integer
    Dim Departamento As String
    Dim Dia As String

    Public Property formIdMetaProduccion As Integer
        Get
            Return IdMetaProduccion
        End Get
        Set(value As Integer)
            IdMetaProduccion = value
        End Set
    End Property

    Public Property FormDepartamento As String
        Get
            Return Departamento
        End Get
        Set(value As String)
            Departamento = value
        End Set
    End Property

    Public Property FormDia As String
        Get
            Return Dia
        End Get
        Set(value As String)
            Dia = value
        End Set
    End Property

    Public Sub llenarTablaMetasPorHora()
        Dim objBu As New MetasProduccionBU
        Dim tablaDatos As New DataTable

        grdMetasProd.DataSource = Nothing
        Try
            If formIdMetaProduccion > 0 Then

                tablaDatos = objBu.TraerDatosMetasPorHora(formIdMetaProduccion)

                If tablaDatos.Rows.Count > 0 Then
                    grdMetasProd.DataSource = tablaDatos
                    Editable = False
                    DiseñoGrid()
                    Button2.Enabled = True
                    btnEditar.Enabled = True
                    btnEstatusAnterior.Enabled = True
                    btnGuardar.Visible = False
                    lblGuardar.Visible = False
                Else
                    plantillaMetasHora()
                    Editable = True
                    DiseñoGrid()
                    Button2.Enabled = False
                    btnEditar.Enabled = False
                    btnEstatusAnterior.Enabled = False
                    btnGuardar.Visible = True
                    lblGuardar.Visible = True
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message())
        End Try
    End Sub

    Private Sub DiseñoGrid()
        vwReporte.OptionsView.ColumnAutoWidth = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        vwReporte.Columns.ColumnByFieldName("idMetaHoras").Visible = False
        vwReporte.Columns.ColumnByFieldName("Hora").Caption = "Hora"
        vwReporte.Columns.ColumnByFieldName("Cantidad").Caption = "Cantidad"

        vwReporte.Columns.ColumnByFieldName("Hora").OptionsColumn.AllowEdit = False

        If Editable = True Then
            vwReporte.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = True
        Else
            vwReporte.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim EditarMetas As New AltaCambiosMetasHoraForm

        If vwReporte.RowCount > 1 Then

            Dim posicionTabla As Integer = vwReporte.GetFocusedDataSourceRowIndex()
            Dim tablaDatos As DataTable
            tablaDatos = grdMetasProd.DataSource

            For i As Integer = 0 To tablaDatos.Rows.Count - 1
                If tablaDatos.Rows.Count > 0 And i = posicionTabla Then
                    EditarMetas.formIdMetaHora = tablaDatos.Rows(i).Item("idMetaHoras")
                    EditarMetas.formHora = tablaDatos.Rows(i).Item("Hora")
                    EditarMetas.formPares = tablaDatos.Rows(i).Item("Cantidad")
                End If
            Next
            EditarMetas.formTablaMetas = grdMetasProd.DataSource
            EditarMetas.formTipoAccion = "Editar"
        End If
        EditarMetas.ShowDialog()
        llenarTablaMetasPorHora()
    End Sub

    Private Sub btnEstatusAnterior_Click(sender As Object, e As EventArgs) Handles btnEstatusAnterior.Click
        Dim objBu As New MetasProduccionBU
        Dim mensajeExito As New ExitoForm
        Dim mensajeError As New ErroresForm
        Dim mensajeConfirmar As New ConfirmarForm
        Dim Inhabilitar As String
        Dim idMetaHora As Integer

        Dim posicionTabla As Integer = vwReporte.GetFocusedDataSourceRowIndex()
        Dim tablaDatos As DataTable
        Dim TablaConfirmacion As DataTable
        Dim respuesta As Integer

        mensajeConfirmar.mensaje = "¿Está seguro de inhabilitar esta meta? El proceso no se podra revertir."
        If mensajeConfirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Inhabilitar = "Baja"
            tablaDatos = grdMetasProd.DataSource
            For i As Integer = 0 To tablaDatos.Rows.Count - 1
                If tablaDatos.Rows.Count > 0 And i = posicionTabla Then
                    idMetaHora = tablaDatos.Rows(i).Item("idMetaHoras")
                End If
            Next
            TablaConfirmacion = objBu.MetasProduccionConfigGlobal_ABC(Inhabilitar, "", 0, idMetaHora, 0)

            For Each row As DataRow In TablaConfirmacion.Rows
                If TablaConfirmacion.Rows.Count > 0 Then
                    respuesta = row.Item("Mensaje").ToString()
                End If
            Next

            If respuesta = 3 Then
                mensajeExito.mensaje = "Se inhabilito con éxito la meta."
                mensajeExito.ShowDialog()
            Else
                mensajeError.mensaje = "Ocurrió un error en el transcurso de la petición."
                mensajeError.ShowDialog()
            End If

        End If
        llenarTablaMetasPorHora()
    End Sub

    Public Sub plantillaMetasHora()
        Dim arrHorasSemana() As String = {"08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00"}
        Dim arrHorasFin() As String = {"09:00", "10:00", "11:00", "12:00", "13:00", "14:00"}
        Dim tbaDatosPlantilla As New DataTable

        tbaDatosPlantilla.Columns.Add("idMetaHoras")
        tbaDatosPlantilla.Columns.Add("Hora")
        tbaDatosPlantilla.Columns.Add("Cantidad")

        If FormDia = "SABADO" Then
            For i As Integer = 0 To arrHorasFin.Length - 1
                tbaDatosPlantilla.Rows.Add(New Object() {0, arrHorasFin(i).ToString(), 0})
            Next
        Else
            For i As Integer = 0 To arrHorasSemana.Length - 1
                tbaDatosPlantilla.Rows.Add(New Object() {0, arrHorasSemana(i).ToString(), 0})
            Next
        End If
        grdMetasProd.DataSource = tbaDatosPlantilla
        DiseñoGrid()
    End Sub

    Public Sub AgregarAPlantilla()
        Dim MetasPlantilla As New AltaCambiosMetasHoraForm

        If vwReporte.RowCount > 1 Then
            Dim posicionTabla As Integer = vwReporte.GetFocusedDataSourceRowIndex()
            Dim tablaDatos As DataTable
            tablaDatos = grdMetasProd.DataSource

            For i As Integer = 0 To tablaDatos.Rows.Count - 1
                If tablaDatos.Rows.Count > 0 And i = posicionTabla Then
                    MetasPlantilla.formIdMetaHora = tablaDatos.Rows(i).Item("idMetaHoras")
                    MetasPlantilla.formHora = tablaDatos.Rows(i).Item("Hora")
                    MetasPlantilla.formPares = tablaDatos.Rows(i).Item("Cantidad")
                End If
            Next
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'MetasProduccionConfigGlobal_ABC
        Dim tablaDeDatos As DataTable
        Dim objBU As New MetasProduccionBU
        Dim confirmarInsert As New ConfirmarForm
        Dim tipoInsert As String
        tipoInsert = "Alta"

        tablaDeDatos = grdMetasProd.DataSource

        confirmarInsert.mensaje = "¿Está seguro de guardar toda la información?"

        If confirmarInsert.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For i As Integer = 0 To tablaDeDatos.Rows.Count - 1
                objBU.MetasProduccionConfigGlobal_ABC(tipoInsert, tablaDeDatos.Rows(i).Item("Hora"), tablaDeDatos.Rows(i).Item("Cantidad"), 0, formIdMetaProduccion)
            Next
        End If
        llenarTablaMetasPorHora()
    End Sub
End Class