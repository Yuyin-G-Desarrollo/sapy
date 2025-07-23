Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Entidades
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools




Public Class CatalogoMotivoCancelacionForm

    Dim AgregarOModificar As Boolean
    Dim IdMotivoCancelacion As Int32
    Dim NombreMotivoCancelacion As String
    Dim DescripcionMotivoCancelacion As String
    Dim Activo As Boolean
    Dim forma As New AgregarEditarMotivosCancelacionForm


    'Botones arriba y abajo
    Private Sub btnArriba_Click_1(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Visible = False
    End Sub
    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Visible = True
    End Sub


    Private Sub CatalogoMotivoCancelacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Location = New Point(0, 0)
        btnEditar.Enabled = False
        LimpiarVariables()
        LlenarTablaMotivoCancelacion()
    End Sub


    Private Sub DisenioDevGrid()
        vwMotivosCancelacion.IndicatorWidth = 50
        For Each col As Columns.GridColumn In vwMotivosCancelacion.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            DiseñoGrid.EstiloColumna(vwMotivosCancelacion, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        Next
        vwMotivosCancelacion.Columns.ColumnByFieldName("esta_estatusid").Visible = False
        vwMotivosCancelacion.OptionsView.ColumnAutoWidth = True

        vwMotivosCancelacion.Columns.ColumnByFieldName("Motivo_Cancelacion").Caption = "Motivo"
        vwMotivosCancelacion.Columns.ColumnByFieldName("Descripcion").Caption = "Descripción"
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim form As New AgregarEditarMotivosCancelacionForm
        form.MotivoCancelacionId = -1
        form.ShowDialog()
        LimpiarVariables()
        LlenarTablaMotivoCancelacion()
    End Sub

    Private Sub LimpiarVariables()
        IdMotivoCancelacion = -1
        NombreMotivoCancelacion = String.Empty
        DescripcionMotivoCancelacion = String.Empty
        btnEditar.Enabled = False
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        'Dim form As New AgregarEditarMotivosCancelacionForm

        'form.MotivoCancelacionId = IdMotivoCancelacion
        'form.MotivoNombre = NombreMotivoCancelacion
        'form.MotivoCancelacionDescripcion = DescripcionMotivoCancelacion
        'form.Activo = Activo
        '
        'LimpiarVariables()


        forma.ShowDialog()
        LlenarTablaMotivoCancelacion()
        btnEditar.Enabled = False


    End Sub

    ''Metodo para llenar variables para editar un registro
    Public Sub LlenarVariableParaEditarRegistro(forma As AgregarEditarMotivosCancelacionForm)
        Dim posicionTabla As Integer = 0
        Dim tabla As DataTable
        If vwMotivosCancelacion.RowCount > 0 Then
            posicionTabla = vwMotivosCancelacion.GetFocusedDataSourceRowIndex

            tabla = grdMotivos.DataSource
            For i As Integer = 0 To tabla.Rows.Count - 1
                If i = posicionTabla Then
                    forma.MotivoCancelacionId = tabla.Rows(i).Item("esta_estatusid")
                    forma.MotivoNombre = tabla.Rows(i).Item("Motivo_Cancelacion")
                    forma.MotivoCancelacionDescripcion = tabla.Rows(i).Item("Descripcion")
                    forma.tipoAccion = "E"
                End If
            Next

        End If

    End Sub

    'llenar tabla motivo cancelación
    Public Sub LlenarTablaMotivoCancelacion()
        Cursor = Cursors.WaitCursor
        grdMotivos.DataSource = Nothing
        IdMotivoCancelacion = 0
        NombreMotivoCancelacion = String.Empty
        DescripcionMotivoCancelacion = String.Empty

        Dim objBU As New Negocios.CatalogoMotivoCancelacionBU
        If rdoSi.Checked = True Then
            Activo = rdoSi.Checked
        Else
            Activo = False
        End If
        Dim dtConsultaMotivosCancelacion As DataTable = objBU.ListaCatalogoMotivoCancelacion(Activo)

        If dtConsultaMotivosCancelacion.Rows.Count > 0 Then
            grdMotivos.DataSource = Nothing
            vwMotivosCancelacion.Columns.Clear()
            grdMotivos.DataSource = dtConsultaMotivosCancelacion
            DisenioDevGrid()

            lblTotal.Text = dtConsultaMotivosCancelacion.Rows.Count
        Else
            grdMotivos.DataSource = Nothing
            vwMotivosCancelacion.Columns.Clear()
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para mostrar")
        End If
        Cursor = Cursors.Default

        ''Asignación de valores a las variables.
        If rdoSi.Checked = False Then
            Activo = False
        Else
            Activo = True
        End If


    End Sub

    Private Sub vwMotivosCancelacion_DoubleClick(sender As Object, e As EventArgs) Handles vwMotivosCancelacion.DoubleClick
        Dim forma As New AgregarEditarMotivosCancelacionForm
        LlenarVariableParaEditarRegistro(forma)
        forma.ShowDialog()
        LlenarTablaMotivoCancelacion()

    End Sub



    Private Sub vwMotivosCancelacion_Click(sender As Object, e As EventArgs) Handles vwMotivosCancelacion.Click
        btnEditar.Enabled = True
        LlenarVariableParaEditarRegistro(forma)
    End Sub





    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub vwMotivosCancelacion_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwMotivosCancelacion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        LimpiarVariables()
        LlenarTablaMotivoCancelacion()
    End Sub


End Class