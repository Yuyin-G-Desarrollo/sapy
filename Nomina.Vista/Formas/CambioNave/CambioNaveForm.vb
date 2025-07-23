Imports DevExpress.XtraGrid
Imports Nomina.Negocios
Imports Tools

Public Class cambioNaveForm
    Dim naveID As Integer
    Private Sub cambioNaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initcombos()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        LlenarTabla()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub initcombos()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub
    Public Sub LlenarTabla()
        Try
            Me.Cursor = Cursors.WaitCursor
            If validarFiltros() Then
                Dim objFiltros As New Entidades.FiltrosFichaColaborador
                Dim objBU As New CambioNaveBU
                Dim idNave = 0
                Dim idDepartamento = 0
                Dim idPuesto = 0

                vwColaboradores.Columns.Clear()
                grdColaboradores.DataSource = Nothing

                If cmbNave.SelectedValue > 0 Then
                    idNave = cmbNave.SelectedValue
                    naveID = cmbNave.SelectedValue
                End If
                If cmbDepto.SelectedIndex > 0 Then
                    idDepartamento = cmbDepto.SelectedValue
                End If
                If cmbPuesto.SelectedIndex > 0 Then
                    idPuesto = cmbPuesto.SelectedValue
                End If

                With objFiltros
                    .PNombre = txtNombre.Text
                    .PCURP = txtCurp.Text
                    .PRFC = txtRFC.Text
                    .PIdNave = idNave
                    .PIdDepartamento = idDepartamento
                    .PIdPuesto = idPuesto
                End With

                Dim dtDatos As New DataTable
                dtDatos = objBU.obtenerListaColaboradores(objFiltros)

                If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
                    grdColaboradores.DataSource = dtDatos
                    disenioGrid()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontró información para mostrar.")
                End If
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al obtener la información.")

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub disenioGrid()
        Tools.DiseñoGrid.AlternarColorEnFilas(vwColaboradores)
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(vwColaboradores)
        vwColaboradores.BestFitColumns()



        vwColaboradores.Columns("patronId").Visible = False
        vwColaboradores.Columns("idNave").Visible = False
        vwColaboradores.Columns.ColumnByFieldName("idCol").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        'vwColaboradores.Columns.ColumnByFieldName("Fila").Caption = "#"

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwColaboradores.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cmbNave.SelectedIndex > 0 Then
            cmbDepto = Controles.ComboDepatamentoSegunNave(cmbDepto, cmbNave.SelectedValue.ToString)
        End If
        grdColaboradores.DataSource = Nothing
    End Sub

    Private Sub cmbDepto_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cmbDepto.SelectedIndex > 0 Then
            cmbPuesto = Controles.ComboPuestosSegunDepartamento(cmbPuesto, cmbDepto.SelectedValue.ToString)
        End If
    End Sub

    Private Sub btnBajaCambioNave_Click(sender As Object, e As EventArgs) Handles btnBajaCambioNave.Click
        abrirCambioNaveColaborador()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub abrirCambioNaveColaborador()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim filaSeleccionada As DataRow = vwColaboradores.GetDataRow(vwColaboradores.FocusedRowHandle)

        If Not filaSeleccionada Is Nothing Then
            Dim idColaborador As Integer = filaSeleccionada.Item("idCol")
            Dim idNave As Integer = filaSeleccionada.Item("idNave")
            Dim nombre As String = filaSeleccionada.Item("Nombre")
            Dim asegurado As Boolean = IIf(filaSeleccionada.Item("Asegurado") = "Si", 1, 0)
            Dim patronOrigen As Integer = filaSeleccionada.Item("patronId")

            Dim objForm As New CambioColaboradorNaveForm
            If Not CheckForm(objForm) Then
                objForm.idColaborador = idColaborador
                objForm.idNave = idNave
                objForm.nombre = nombre
                objForm.asegurado = asegurado
                objForm.patronOrigenId = patronOrigen
                objForm.ShowDialog()
                If objForm.guardado Then
                    cargarListado()
                End If
            End If
        Else
            objMensajeAdv.mensaje = "Favor de seleccionar un colaborador."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Public Sub cargarListado()
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        grdColaboradores.DataSource = Nothing
        Try
            If validarFiltros() Then
                Dim objBu As New Negocios.CambioNaveBU
                Dim dtListado As New DataTable
                Dim naveId As Integer = cmbNave.SelectedValue
                Dim nombre As String = txtNombre.Text

                '' dtListado = objBu.obtenerListaColaboradores(naveId, patronId, asegurado, nombre)
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        ''grdListado.DataSource = dtListado
                        disenioGrid()
                    Else
                        objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                        objMensajeAdv.Show()
                    End If
                Else
                    objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                    objMensajeAdv.Show()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar listado de colaboradores."
            objMensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function validarFiltros() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbNave.Items.Count > 1 And cmbNave.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Nave."
            objMensajeAdv.ShowDialog()
            Return False
        End If
        Return True
    End Function

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros2.Visible = False
    End Sub
    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros2.Visible = True
    End Sub

End Class