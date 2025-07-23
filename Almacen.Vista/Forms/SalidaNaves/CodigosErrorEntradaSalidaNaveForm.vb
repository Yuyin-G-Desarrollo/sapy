Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class CodigosErrorEntradaSalidaNaveForm
    Public ListaCodigosError As New List(Of Entidades.CodigosErroneos)
    Public IdSalidaNave As Integer
    Public Plataformas As Boolean ''TRUE PARA PLATAFORMAS, FALSE PARA CODIGOS CON ERROR
    Public IdNave As Integer
    Public TipoProceso As String = String.Empty
    Private ObjBU As New Almacen.Negocios.SalidasAlmacenBU
    Private Sub CodigosErrorEntradaSalidaNaveForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Plataformas = True Then
                CaragarPlataformas()
            Else
                If TipoProceso = "SALIDA" Then
                    CargarCodigosError()
                ElseIf TipoProceso = "ENTRADA" Then
                    CargarCodigosError()
                End If
            End If
        Catch ex As Exception
            Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Errores, ex.Message.ToString)
        End Try

    End Sub

    Private Sub CaragarPlataformas()
        Dim DtResultado As New DataTable
        Try
            DtResultado = ObjBU.ObtenerPlataformasFolioEntrada(IdSalidaNave)
            grdCodigos.DataSource = Nothing
            grdCodigos.DataSource = DtResultado
            DiseñoGridPlataformas(grdCodigos)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCodigosError()
        grdCodigos.DataSource = Nothing
        grdCodigos.DataSource = ListaCodigosError
        DiseñoGridCodigosError(grdCodigos)
    End Sub

    Private Sub grdCodigos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCodigos.InitializeLayout
        Try
            With grdCodigos
                .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 'Ajusta todas las columnas a un tamaño igual.
                .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
                .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
                .DisplayLayout.Override.RowSelectorWidth = 35
                .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
                .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
                .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
                .DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy
                If Plataformas = False Then
                    .DisplayLayout.Bands(0).Columns(0).Header.Caption = "Errores"
                End If

            End With
        Catch ex As Exception

        End Try

    End Sub


    Private Sub DiseñoGridCodigosError(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim IndicePrimerColumna As Integer = 0
        Dim UltimaColumna As Integer = 0
        Dim Layout As UltraGridLayout = grid.DisplayLayout

        Try
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            grid.DisplayLayout.Bands(0).Columns("FolioSalidaID").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Atado").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("CodigoLeido").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("Proceso").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("DescripcionError").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("Lote").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("Año").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("NaveSICYID").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("UsuarioID").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Usuario").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("ClienteSICYID").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Fecha").Hidden = True

            grid.DisplayLayout.Bands(0).Columns("FolioSalidaID").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Atado").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("CodigoLeido").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Proceso").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("DescripcionError").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Lote").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Año").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("NaveSICYID").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("UsuarioID").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Usuario").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("ClienteSICYID").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Fecha").CellAppearance.TextHAlign = HAlign.Right


            grid.DisplayLayout.Bands(0).Columns("FolioSalidaID").Header.Caption = "FolioSalidaID"
            grid.DisplayLayout.Bands(0).Columns("Atado").Header.Caption = "Atado"
            grid.DisplayLayout.Bands(0).Columns("CodigoLeido").Header.Caption = "Codigo Leido"
            grid.DisplayLayout.Bands(0).Columns("Proceso").Header.Caption = "Proceso"
            grid.DisplayLayout.Bands(0).Columns("DescripcionError").Header.Caption = "Descripción Error"
            grid.DisplayLayout.Bands(0).Columns("Lote").Header.Caption = "Lote"
            grid.DisplayLayout.Bands(0).Columns("Año").Header.Caption = "Año"
            grid.DisplayLayout.Bands(0).Columns("NaveSICYID").Header.Caption = "NaveSICYID"
            grid.DisplayLayout.Bands(0).Columns("UsuarioID").Header.Caption = "UsuarioID"
            grid.DisplayLayout.Bands(0).Columns("Usuario").Header.Caption = "Usuario"
            grid.DisplayLayout.Bands(0).Columns("ClienteSICYID").Header.Caption = "ClienteSICYID"
            grid.DisplayLayout.Bands(0).Columns("Fecha").Header.Caption = "Fecha"

            grid.DisplayLayout.Bands(0).Columns("FolioSalidaID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Atado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("CodigoLeido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Proceso").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("DescripcionError").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Lote").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Año").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("NaveSICYID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("UsuarioID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Usuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("ClienteSICYID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DiseñoGridPlataformas(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim IndicePrimerColumna As Integer = 0
        Dim UltimaColumna As Integer = 0
        Dim Layout As UltraGridLayout = grid.DisplayLayout

        Try
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            grid.DisplayLayout.Bands(0).Columns("IDPlataforma").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("Plataforma").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("NumeroAtados").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("ParesAtados").Hidden = False

            grid.DisplayLayout.Bands(0).Columns("IDPlataforma").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Plataforma").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("NumeroAtados").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("ParesAtados").CellAppearance.TextHAlign = HAlign.Right

            grid.DisplayLayout.Bands(0).Columns("IDPlataforma").Header.Caption = "ID_Plataforma"
            grid.DisplayLayout.Bands(0).Columns("Plataforma").Header.Caption = "Plataforma"
            grid.DisplayLayout.Bands(0).Columns("NumeroAtados").Header.Caption = "Número Atados"
            grid.DisplayLayout.Bands(0).Columns("ParesAtados").Header.Caption = "Número Pares"

            grid.DisplayLayout.Bands(0).Columns("IDPlataforma").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Plataforma").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("NumeroAtados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("ParesAtados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class