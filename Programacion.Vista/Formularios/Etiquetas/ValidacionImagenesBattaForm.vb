Imports Tools

Public Class ValidacionImagenesBattaForm

    Public dtModelosSinCargarImagen As New DataTable

    Private Sub ValidacionImagenesBattaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarGrid()
    End Sub


    Private Sub CargarGrid()
        Try
            grdModelosBatta.DataSource = Nothing
            grdModelosBatta.DataSource = dtModelosSinCargarImagen
            DiseñoGrid(viewModelosBatta)
        Catch ex As Exception
            show_message("Error", ex.Message)
            'show_message("Error", "Ocurrio un error al mostrar la información.")
        End Try

    End Sub
    Private Sub DiseñoGrid(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView)
        grid.OptionsView.ColumnAutoWidth = True
        grid.BestFitColumns()
        grid.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        With grid

            .Columns.ColumnByFieldName("DescripcionCompleta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("MarcaSAY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("ModeloSAY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Color").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Piel").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("CorridaAgrupamiento").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            .Columns.ColumnByFieldName("DescripcionCompleta").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("MarcaSAY").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("ModeloSAY").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Color").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Piel").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("CorridaAgrupamiento").OptionsColumn.AllowSize = True

            .Columns.ColumnByFieldName("DescripcionCompleta").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("MarcaSAY").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("ModeloSAY").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Color").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Piel").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("CorridaAgrupamiento").OptionsColumn.AllowEdit = False

            .Columns.ColumnByFieldName("DescripcionCompleta").Caption = "Artículo"
            .Columns.ColumnByFieldName("MarcaSAY").Caption = "Marca"
            .Columns.ColumnByFieldName("ModeloSAY").Caption = "Modelo"
            .Columns.ColumnByFieldName("Color").Caption = "Color"
            .Columns.ColumnByFieldName("Piel").Caption = "Piel"
            .Columns.ColumnByFieldName("CorridaAgrupamiento").Caption = "Corrida"

        End With


    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub




    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub





End Class