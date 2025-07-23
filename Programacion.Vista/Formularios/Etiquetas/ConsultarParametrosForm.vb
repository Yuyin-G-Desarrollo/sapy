Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration
Imports System.IO

Public Class ConsultarParametrosForm

    Dim ObjBU As New Programacion.Negocios.EtiquetasBU


    Private Sub ConsultarParametrosForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        CargarGrid()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub CargarGrid()
        Try
            grdParametrosEtiquetas.DataSource = Nothing
            grdParametrosEtiquetas.DataSource = ObjBU.ConsultarParametrosRelacionados()
            DiseñoGrid(viewParametrosEtiquetas)
            lblTotalSeleccionados.Text = CDbl(viewParametrosEtiquetas.DataRowCount).ToString()
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
            '.Columns.ColumnByFieldName("ParametroID").Visible = False
            '.Columns.ColumnByFieldName("Parametro").Visible = True
            '.Columns.ColumnByFieldName("Descripción").Visible = False
            '.Columns.ColumnByFieldName("Número").Visible = False
            '.Columns.ColumnByFieldName("Activa").Visible = False
            '.Columns.ColumnByFieldName("Valor Etiqueta").Visible = True
            '.Columns.ColumnByFieldName("Seleccionar").Visible = False

            .OptionsView.EnableAppearanceEvenRow = True
            .OptionsView.EnableAppearanceOddRow = True

            .Columns.ColumnByFieldName("Parámetro").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Valor Etiqueta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            .Columns.ColumnByFieldName("ParametroID").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("ParametroID").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Parámetro").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Descripción").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("Número").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("Activa").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Ejemplo").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Valor Etiqueta").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("Seleccionar").OptionsColumn.AllowSize = True

            .Columns.ColumnByFieldName("ParametroID").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("ParametroID").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Parámetro").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Descripción").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("Número").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Ejemplo").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("Activa").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Valor Etiqueta").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("Seleccionar").OptionsColumn.AllowEdit = False

            .Columns.ColumnByFieldName("ParametroID").Caption = "#"

        End With


    End Sub


    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then

                    If viewParametrosEtiquetas.GroupCount > 0 Then
                        grdParametrosEtiquetas.ExportToXlsx(.SelectedPath + "\CatalogoParametrosEtiquetas_" + fecha_hora + ".xlsx")
                    Else
                        grdParametrosEtiquetas.ExportToXlsx(.SelectedPath + "\CatalogoParametrosEtiquetas_" + fecha_hora + ".xlsx")
                    End If

                    show_message("Exito", "Los datos se exportaron correctamente: " & "CatalogoParametrosEtiquetas_" & fecha_hora.ToString() & ".xlsx")

                    .Dispose()

                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\CatalogoParametrosEtiquetas_" + fecha_hora + ".xlsx")
                End If
            End With
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
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