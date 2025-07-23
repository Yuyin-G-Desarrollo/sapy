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

Public Class MostrarDetallesValidacionTallasExtanjerasForm

    Dim ObjBU As New Programacion.Negocios.EtiquetasBU
    Public LoteInicio As Integer = 0
    Public LoteFin As Integer = 0
    Public NaveSIYCID As Integer = 0
    Public ColeccionID As Integer = 0
    Public AñoPrograma As Integer = 0
    Public ClienteSICYId As Integer = 0
    Public FechaPrograma As Date
    Public EsEtiquetaPrueba As Boolean = False
    Public TipoEtiqueta As Integer = 0 '1 => LENGUA , 2 => RASTREO, 3 => Pares

    Private Sub MostrarDetallesValidacionTallasExtanjerasForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            CargarPantalla()
            DiseñoGrid(ViewDetallesTallasExtranjeras)
        Catch ex As Exception
            show_message("Advertencia", ex.Message.ToString())
        End Try
        
    End Sub

    Private Sub CargarPantalla()
        Dim dtInformacion As New DataTable

        Try
            grdDetallesTallasExtranjeras.DataSource = Nothing
            If TipoEtiqueta = 1 Then
                dtInformacion = ObjBU.MostrarDetallesTallasExtranjerasLengua(LoteInicio, LoteFin, NaveSIYCID, ColeccionID, AñoPrograma, FechaPrograma, EsEtiquetaPrueba)
            ElseIf TipoEtiqueta = 2 Then
                dtInformacion = ObjBU.MostrarDetallesTallasExtranjerasRastreo(LoteInicio, LoteFin, NaveSIYCID, ClienteSICYId, AñoPrograma, FechaPrograma, EsEtiquetaPrueba)
            ElseIf TipoEtiqueta = 3 Then
                dtInformacion = ObjBU.MostrarDetallesTallasExtranjerasPares(LoteInicio, LoteFin, NaveSIYCID, AñoPrograma, FechaPrograma)
            End If
            grdDetallesTallasExtranjeras.DataSource = dtInformacion
        Catch ex As Exception
            show_message("Advertencia", ex.Message.ToString())
        End Try

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

    Private Sub DiseñoGrid(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView)
        grid.OptionsView.ColumnAutoWidth = True
        grid.BestFitColumns()
        grid.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(grid)
        Tools.DiseñoGrid.AlternarColorEnFilas(grid)

        With grid
            .Columns.ColumnByFieldName("Cliente").Visible = True
            .Columns.ColumnByFieldName("Familia").Visible = False
            .Columns.ColumnByFieldName("Talla").Visible = True
            .Columns.ColumnByFieldName("Status").Visible = True

            .Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Familia").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Talla").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Status").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains


            .Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Familia").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Talla").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Status").OptionsColumn.AllowSize = True

            
            .Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Familia").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Talla").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Status").OptionsColumn.AllowEdit = False


        End With


    End Sub




End Class