Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class ArticulosFaltantesenSAPForm
    Private Sub ArticulosFaltantesenSAPForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTitulo.Text = "Artículos Faltantes en SAP"
        diseñoGrid()

    End Sub

    Private Sub diseñoGrid()

        With grdArticulosFaltantesenSAP.DisplayLayout
            .Bands(0).Columns(0).Header.Caption = "ID Artículo"
            .Bands(0).Columns(1).Header.Caption = "Artículo"
            .Bands(0).Columns(2).Header.Caption = "Categoría"
            .Bands(0).Columns(3).Header.Caption = "Grupo"
            .Bands(0).Columns(4).Header.Caption = "Status"
            .Bands(0).Columns(5).Header.Caption = "Nave Des.Id"
            .Bands(0).Columns(6).Header.Caption = "Nave Desarrollo"
            .Bands(0).Columns(7).Header.Caption = "Marca SAY Id"
            .Bands(0).Columns(8).Header.Caption = "Marca SAY"
            .Bands(0).Columns(9).Header.Caption = "Fam.Proyección"
            .Bands(0).Columns(10).Header.Caption = "ColeccionSAY"
            .Bands(0).Columns(11).Header.Caption = "ModeloSAY"
            .Bands(0).Columns(12).Header.Caption = "Corrida"
            .Bands(0).Columns(13).Header.Caption = "PielColor"
            .Bands(0).Columns(14).Header.Caption = "pres_clavesat_detallada"
            .Bands(0).Columns(15).Header.Caption = "ClaveSatGeneral"
            .Bands(0).Columns(16).Header.Caption = "pcsd_clavesat_general"
            .Bands(0).Columns(17).Header.Caption = "Fam.ProyecciónId"
            .Bands(0).Columns(18).Header.Caption = "Fam.Proyección"

            '  .Bands(0).Columns(2).Hidden = True
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            ' .AutoFitStyle = AutoFitStyle.ResizeAllColumns

            .Bands(0).Columns("ID").CellActivation = Activation.NoEdit
            .Bands(0).Columns("Articulo").CellActivation = Activation.NoEdit
            .Bands(0).Columns("ID").Width = 48
            .Bands(0).Columns("Articulo").Width = 320
            .Bands(0).Columns("TipoCategoria").Width = 74
            .Bands(0).Columns("GroupName").Width = 40
            .Bands(0).Columns("Status").Width = 230
            .Bands(0).Columns("NaveDesarrolloId").Width = 78
            .Bands(0).Columns("NaveDesarrollo").Width = 115
            .Bands(0).Columns("MarcaSAYId").Width = 76
            .Bands(0).Columns("MarcaSAY").Width = 84
            .Bands(0).Columns("FamiliaProyección").Width = 114
            .Bands(0).Columns("ColeccionSay").Width = 105
            .Bands(0).Columns("ModeloSAY").Width = 70
            .Bands(0).Columns("CorridaAgrupamiento").Width = 48
            .Bands(0).Columns("PielColor").Width = 129
            .Bands(0).Columns("pres_clavesat_detallada").Width = 131
            .Bands(0).Columns("ClaveSatGeneral").Width = 97
            .Bands(0).Columns("pcsd_clavesat_general").Width = 146
            .Bands(0).Columns("FamiliaProyeccionId").Width = 100
            .Bands(0).Columns("FamiliaProyeccion").Width = 114

            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowRowFiltering = DefaultableBoolean.True
        End With

        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2
    End Sub
End Class