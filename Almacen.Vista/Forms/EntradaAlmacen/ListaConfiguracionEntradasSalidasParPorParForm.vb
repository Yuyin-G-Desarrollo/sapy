Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListaConfiguracionEntradasSalidasParPorParForm

    Dim IdNave As Integer
    Dim IdCadena As Integer
    Dim IdConfiguracion As Integer
    Dim Salida As Boolean
    Dim Entrada As Boolean

    Private Sub ListaConfiguracionEntradasSalidasParPorParForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        PoblarGridConfiguracionDeValidaciones()

    End Sub


    Private Sub PoblarGridConfiguracionDeValidaciones()
        Dim objBU As New Negocios.EntradaProductoBU
        grdListaConfiguracionParPorPar.DataSource = objBU.PoblarGridConfiguracionDeValidaciones()
    End Sub

    Private Sub grdListaConfiguracionParPorPar_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdListaConfiguracionParPorPar.InitializeLayout
        With grdListaConfiguracionParPorPar
            .DisplayLayout.Bands(0).Columns("IDCONFIGURACION").Hidden = True
            .DisplayLayout.Bands(0).Columns("IDCLIENTE").Hidden = True
            .DisplayLayout.Bands(0).Columns("IDNAVE").Hidden = True

            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 'Ajusta todas las columnas a un tamaño igual.
            .DisplayLayout.Bands(0).Columns(1).Width = 300 'Ajusta la columna indicada a un tamaño manualmente asignado.

            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35

            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No

            .DisplayLayout.Bands(0).Columns("CLIENTE").Width = 300

        End With
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim Forma As New Agregar_o_Editar_ConfiguracionEmbarquesParPorParForm
        Forma.StartPosition = FormStartPosition.CenterScreen
        Forma.Editar = False
        Forma.ShowDialog()
        limpiarVariablesYGrid()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim Forma As New Agregar_o_Editar_ConfiguracionEmbarquesParPorParForm
        Dim formaAdvertencia As New AdvertenciaForm
        Forma.StartPosition = FormStartPosition.CenterScreen

        If IdNave = 0 Then
            formaAdvertencia.mensaje = "Debes seleccionar primero un registro de la tabla para poder editar."
            formaAdvertencia.ShowDialog()
        Else
            Forma.Editar = True
            Forma.IdNave = IdNave
            Forma.IdCadena = IdCadena
            Forma.idConfiguracion = IdConfiguracion
            Forma.Salida = Salida
            Forma.Entrada = Entrada
            Forma.ShowDialog()

        End If
        limpiarVariablesYGrid()
    End Sub

    Private Sub limpiarVariablesYGrid()
        IdNave = 0
        IdCadena = 0
        IdConfiguracion = 0
        Salida = False
        Entrada = False

        grdListaConfiguracionParPorPar.DataSource = Nothing
        PoblarGridConfiguracionDeValidaciones()
    End Sub

    Private Sub grdListaConfiguracionParPorPar_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaConfiguracionParPorPar.ClickCell
        Dim row As UltraGridRow = grdListaConfiguracionParPorPar.ActiveRow
        If row.IsFilterRow Then Return
        IdConfiguracion = CInt(row.Cells("IDCONFIGURACION").Text)
        IdCadena = CInt(row.Cells("IDCLIENTE").Text)
        IdNave = CInt(row.Cells("IDNAVE").Value)

        If row.Cells("VALIDAR SALIDA").Text = "NO" Then
            Salida = False
        Else
            Salida = True
        End If

        If row.Cells("VALIDAR ENTRADA").Text = "NO" Then
            Entrada = False
        Else
            Entrada = True
        End If
    End Sub
End Class