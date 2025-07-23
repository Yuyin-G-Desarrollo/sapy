Imports Tools
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.GridView
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration
Imports System.Data.OleDb
Imports System.Data

Public Class ListadoEtiquetasDiferenteTamañoForm

    Public Lotes As String = String.Empty
    Public Año As Integer = 0
    Public FechaPrograma As Date
    Public NaveSICYID As Integer = 0
    Private ObjBU As New Programacion.Negocios.EtiquetasBU

    Private Sub ListadoEtiquetasDiferenteTamañoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarInformacion()
    End Sub

    Private Sub CargarInformacion()
        Dim dtInformacionEtiquetasDiferenteTamaño As New DataTable
        Try
            dtInformacionEtiquetasDiferenteTamaño = ObjBU.ConsultaEtiquetasDiferenteTamaño(Lotes, NaveSICYID, Año, FechaPrograma)
            grdEtiquetasDiferenteTamaño.DataSource = dtInformacionEtiquetasDiferenteTamaño
            DiseñoGrid(viewEtiquetasDiferenteTamaño)
        Catch ex As Exception
            show_message("Error", "Ocurrio un error al cargar la información.")
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

    Private Sub DiseñoGrid(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        'If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
        '    Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        '    AddHandler Grid.CustomUnboundColumnData, AddressOf grdVEtiquetasEspeciales_CustomUnboundColumnData
        '    Grid.Columns.Item("#").VisibleIndex = 0
        '    Grid.Columns.Item("#").OptionsColumn.AllowEdit = False
        'End If

        Tools.DiseñoGrid.AlternarColorEnFilas(Grid)

        'Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        'Grid.Appearance.FocusedRow.ForeColor = Color.White
        'Grid.Appearance.FocusedCell.BackColor = Color.FromArgb(0, 120, 215)
        'Grid.Appearance.FocusedCell.ForeColor = Color.White
       
        Grid.Columns.ColumnByFieldName("ClienteId").Visible = False
        Grid.Columns.ColumnByFieldName("NombreCliente").Visible = True        
        Grid.Columns.ColumnByFieldName("ClaveEtiqueta").Visible = True
        Grid.Columns.ColumnByFieldName("AnchoEtiqueta").Visible = True
        Grid.Columns.ColumnByFieldName("AltoEtiqueta").Visible = True

        Grid.Columns.ColumnByFieldName("ClienteId").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("NombreCliente").OptionsColumn.AllowEdit = False        
        Grid.Columns.ColumnByFieldName("ClaveEtiqueta").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("AnchoEtiqueta").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("AltoEtiqueta").OptionsColumn.AllowEdit = False

        Grid.Columns.ColumnByFieldName("ClienteId").Caption = "ClienteID"
        Grid.Columns.ColumnByFieldName("NombreCliente").Caption = "Cliente"        
        Grid.Columns.ColumnByFieldName("ClaveEtiqueta").Caption = "Clave Etiqueta"
        Grid.Columns.ColumnByFieldName("AnchoEtiqueta").Caption = "Ancho Etiqueta"
        Grid.Columns.ColumnByFieldName("AltoEtiqueta").Caption = "Alto Etiqueta"

        Grid.BestFitColumns()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class