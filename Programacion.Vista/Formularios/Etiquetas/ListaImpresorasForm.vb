Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils

Public Class ListaImpresorasForm

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Enum StatusImpresoraZebra
        ACTIVA = 1
        INACTIVO = 0
    End Enum

    Private Sub ListaImpresorasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized

        Me.Location = New Point(0, 0)
        CargarGrid()
        DiseñoGridImpresoraZebra(grdVImpresoras)
    End Sub

    Private Sub DiseñoGridImpresoraZebra(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Grid.OptionsView.ColumnAutoWidth = True
        Grid.OptionsView.BestFitMaxRowCount = -1

        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVImpresorasZebra_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If

        Grid.OptionsView.EnableAppearanceEvenRow = True
        Grid.OptionsView.EnableAppearanceOddRow = True
        Grid.OptionsSelection.EnableAppearanceFocusedCell = True
        Grid.OptionsSelection.EnableAppearanceFocusedRow = True
        Grid.Appearance.SelectedRow.Options.UseBackColor = True

        Grid.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        Grid.Appearance.EvenRow.BackColor = Color.White
        Grid.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        Grid.Appearance.FocusedCell.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedCell.ForeColor = Color.White

        Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedRow.ForeColor = Color.White

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        Grid.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Nombre").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Comando").Visible = False
        Grid.Columns.ColumnByFieldName("StImpresora").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Resolucion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Abreviatura").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("IdImpresora").Visible = False
        Grid.Columns.ColumnByFieldName("user_username").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaCreacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("user_username1").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaModificacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("EquipoAsignado").OptionsColumn.AllowEdit = False

        Grid.Columns.ColumnByFieldName("FechaCreacion").DisplayFormat.FormatType = FormatType.DateTime
        Grid.Columns.ColumnByFieldName("FechaCreacion").DisplayFormat.FormatString = "dd/MM/yyyy h:mm:ss tt"
        Grid.Columns.ColumnByFieldName("FechaModificacion").DisplayFormat.FormatType = FormatType.DateTime
        Grid.Columns.ColumnByFieldName("FechaModificacion").DisplayFormat.FormatString = "dd/MM/yyyy h:mm:ss tt"

        Grid.Columns.ColumnByFieldName("Nombre").Caption = "Nombre"
        Grid.Columns.ColumnByFieldName("Resolucion").Caption = "Resolución"
        Grid.Columns.ColumnByFieldName("Abreviatura").Caption = "Abreviatura"
        Grid.Columns.ColumnByFieldName("StImpresora").Caption = "Activo"
        Grid.Columns.ColumnByFieldName("user_username").Caption = "Creó"
        Grid.Columns.ColumnByFieldName("FechaCreacion").Caption = "Fecha Creación"
        Grid.Columns.ColumnByFieldName("user_username1").Caption = "Usuario Modificó"
        Grid.Columns.ColumnByFieldName("FechaModificacion").Caption = "Fecha Modificación"
        Grid.Columns.ColumnByFieldName("EquipoAsignado").Caption = "Equipo Asignado"



        Grid.BestFitColumns()
    End Sub

    Private Sub CargarGrid()
        Dim objNeg As New Programacion.Negocios.EtiquetasBU
        Dim dtImpresoras As DataTable

        Try
            dtImpresoras = objNeg.ConsultarImpresorasZebra()
            If dtImpresoras.Rows.Count > 0 Then
                grdImpresoras.DataSource = dtImpresoras
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim AltaImpresoraForm As New AltaImpresoraForm
        AltaImpresoraForm.Accion = "INSERTAR"
        AltaImpresoraForm.ShowDialog()
        CargarGrid()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        EditarImpresora()
    End Sub


    Private Sub EditarImpresora()
        Dim AltaImpresoraForm As New AltaImpresoraForm
        Dim entidadImpresora As New Entidades.ImpresorasZebra
        entidadImpresora.idImpresora = CInt(grdVImpresoras.GetFocusedRowCellValue("IdImpresora"))
        entidadImpresora.Nombre = grdVImpresoras.GetFocusedRowCellValue("Nombre").ToString
        'entidadImpresora.Comando = grdVImpresoras.GetFocusedRowCellValue("Comando").ToString
        entidadImpresora.StImpresion = grdVImpresoras.GetFocusedRowCellValue("StImpresora").ToString
        entidadImpresora.Resolucion = grdVImpresoras.GetFocusedRowCellValue("Resolucion").ToString
        entidadImpresora.Abreviatura = grdVImpresoras.GetFocusedRowCellValue("Abreviatura").ToString
        AltaImpresoraForm.Accion = "ACTUALIZAR"
        AltaImpresoraForm.Entidad = entidadImpresora
        AltaImpresoraForm.ShowDialog()
        CargarGrid()
    End Sub

    Private Sub grdVImpresorasZebra_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVImpresoras.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub grdVImpresoras_RowClick(sender As Object, e As RowClickEventArgs) Handles grdVImpresoras.RowClick
        If e.Clicks = 2 Then
            EditarImpresora()
        End If
    End Sub

    Private Sub btnAsignarImpresora_Click(sender As Object, e As EventArgs) Handles btnAsignarImpresora.Click
        Dim objNegocios As New Negocios.EtiquetasBU
        Dim NombreEquipo As String
        Dim IdImpresora As Integer
        Dim msg_Confirmacion As New Tools.ConfirmarForm
        Dim equipo As String
        Dim msg_info As New Tools.AvisoForm

        Try

            IdImpresora = CInt(grdVImpresoras.GetFocusedRowCellValue("IdImpresora").ToString)
            equipo = grdVImpresoras.GetFocusedRowCellValue("EquipoAsignado").ToString
            NombreEquipo = My.Computer.Name

            If equipo <> String.Empty Then
                If equipo <> NombreEquipo Then
                    msg_Confirmacion.mensaje = "La impresora seleccionada ya está asignada a otro equipo. ¿Desea continuar y remplazar el equipo?"
                    If msg_Confirmacion.ShowDialog <> Windows.Forms.DialogResult.OK Then
                        Return
                    End If
                ElseIf equipo = NombreEquipo Then
                    msg_info.mensaje = "La impresora seleccionada ya está asignada a este equipo."
                    msg_info.ShowDialog()
                    Return
                End If
            End If

            objNegocios.AsignarEquípoPorDefecto(NombreEquipo, IdImpresora)
            CargarGrid()
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub
End Class