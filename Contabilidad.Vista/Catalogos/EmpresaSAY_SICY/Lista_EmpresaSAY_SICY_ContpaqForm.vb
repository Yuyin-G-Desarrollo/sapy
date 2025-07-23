Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports System.Drawing
Imports Contabilidad.Negocios

Public Class Lista_EmpresaSAY_SICY_ContpaqForm

    Dim objAdvertencia As New Tools.AdvertenciaForm


    Private Sub Lista_EmpresaSAY_SICY_ContpaqForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        poblar_gridListaEmpresa(gridListaEmpresa)
    End Sub

    'CONTACTO
    Public Sub poblar_gridListaEmpresa(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim EmpresaSAY_SICY_ContpaqBU As New EmpresaSAY_SICY_ContpaqBU
        Dim PolizaBU As New PolizaBU
        Dim empresa, contribuyente, documento, base_compaq As DataTable
        Dim vlcontribuyente, vldocumento, vlbase_compaq As New ValueList

        empresa = EmpresaSAY_SICY_ContpaqBU.Consulta_lista_Tipo_Poliza

        contribuyente = PolizaBU.Combo_lista_Contribuyentes
        For Each fila As DataRow In contribuyente.Rows
            vlcontribuyente.ValueListItems.Add(fila.Item("IDRazSoc"), fila.Item("RazonSocial"))
        Next

        documento = PolizaBU.Combo_lista_Documentos_SICY
        For Each fila As DataRow In documento.Rows
            vldocumento.ValueListItems.Add(fila.Item("IdDocumento"), fila.Item("RazonSocial"))
        Next

        base_compaq = PolizaBU.Combo_lista_Bases_Contpaq
        For Each fila As DataRow In base_compaq.Rows
            vlbase_compaq.ValueListItems.Add(fila.Item("name"), fila.Item("name"))
        Next

        grid.DataSource = empresa
        grid.DisplayLayout.Bands(0).Columns("Razón Social").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grid.DisplayLayout.Bands(0).Columns("Razón Social").ValueList = vlcontribuyente
        grid.DisplayLayout.Bands(0).Columns("Documento").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grid.DisplayLayout.Bands(0).Columns("Documento").ValueList = vldocumento
        grid.DisplayLayout.Bands(0).Columns("Base Contpaq").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grid.DisplayLayout.Bands(0).Columns("Base Contpaq").ValueList = vlbase_compaq

        gridListaEmpresaDiseno(grid)

        'For Each row As UltraGridRow In grid.Rows

        '    If row.Index > 0 Then
        '        If row.Cells(4).Value = grid.Rows(row.Index - 1).Cells(4).Value Then
        '            row.Cells(4).Value = Nothing
        '            row.Cells(5).Value = Nothing
        '        End If
        '    End If

        'Next

    End Sub


    Private Sub gridListaEmpresaDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        With grid.DisplayLayout
            .Bands(0).Columns("ID").Hidden = True
            .Bands(0).Columns("SAY ID").Hidden = True
            .Bands(0).Columns("RazSoc ID").Hidden = True
            .Bands(0).Columns("Doc ID").Hidden = True
            .Bands(0).Columns("Base ID").Hidden = True
            .Bands(0).Columns("essc_servidor").Hidden = True
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectors = DefaultableBoolean.True
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.FilterUIType = FilterUIType.FilterRow
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

    End Sub


    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim FormaRelacionEmpresa As New RelacionarEmpresaSaySicyContpaqForm
        FormaRelacionEmpresa.AltaEdicion = True
        FormaRelacionEmpresa.StartPosition = FormStartPosition.CenterScreen
        FormaRelacionEmpresa.ShowDialog()
        poblar_gridListaEmpresa(gridListaEmpresa)


    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        If gridListaEmpresa.Selected.Rows.Count > 1 Then
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "Seleccione solo un registro para poder editarlo."
            objAdvertencia.ShowDialog()
        ElseIf gridListaEmpresa.Selected.Rows.Count = 0 Then
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "Seleccione un registro para poder editarlo."
            objAdvertencia.ShowDialog()
        ElseIf IsDBNull(gridListaEmpresa.Selected.Rows(0).Cells("ID").Text) = False And gridListaEmpresa.Selected.Rows(0).Cells("ID").Text <> "" Then

            Dim FormaRelacionEmpresa As New RelacionarEmpresaSaySicyContpaqForm
            Dim objEmpresaSSC As New Entidades.EmpresaSAY_SICY

            For Each row As UltraGridRow In gridListaEmpresa.Selected.Rows
                objEmpresaSSC.empresaid = row.Cells("ID").Value
                objEmpresaSSC.sayid = row.Cells("SAY ID").Value
                objEmpresaSSC.contribuyentesicyid = row.Cells("RazSoc ID").Value
                objEmpresaSSC.doctoventassicyid = row.Cells("Doc ID").Value
                objEmpresaSSC.empresacontpaq = row.Cells("Base ID").Text
                objEmpresaSSC.servidor = row.Cells("essc_servidor").Text
                objEmpresaSSC.razonsocial = row.Cells("Razón Social").Text
            Next

            FormaRelacionEmpresa.objEmpresaSSC = objEmpresaSSC
            FormaRelacionEmpresa.AltaEdicion = False
            FormaRelacionEmpresa.StartPosition = FormStartPosition.CenterScreen
            FormaRelacionEmpresa.ShowDialog()
            poblar_gridListaEmpresa(gridListaEmpresa)
        Else
            objAdvertencia.mensaje = "Esta empresa no tiene una relación con empresa Sicy y Contpaq"
            objAdvertencia.ShowDialog()
        End If




    End Sub


End Class