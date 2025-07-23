Imports Tools.Controles
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ConfigProduccionBandaForm

    Dim IdProduccion As Integer = 0
    Dim IdNave As Integer
    Dim IdPeriodo As Integer
    Dim idcelula As Integer = 0
    Dim FechaInicial As Date
    Dim FechaFinal As Date
    Dim Activo As String
    Dim Consulta As Boolean
    Dim IdDepartamento As Integer

    Private Sub ConfigProduccionBanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub


    ''' <summary>
    ''' LLENA EL GRID GRSPRODUCCIONCELULA CON LOS DATOS DE NAVE, PERIODO Y BANDA
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub TablaProduccionPorBanda()
        grdProduccionCelula.DataSource = Nothing
        Dim objProduccionPorBanda As New Negocios.NominaDestajosBU
        Dim dtProduccionPorBanda As New DataTable
        dtProduccionPorBanda = objProduccionPorBanda.TablaProduccion(cmbNave.SelectedValue, cmbPeriodo.SelectedValue)
        grdProduccionCelula.DataSource = dtProduccionPorBanda
    End Sub

    Private Sub grdProduccionCelula_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdProduccionCelula.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdProduccionCelula_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdProduccionCelula.InitializeLayout
        With grdProduccionCelula
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Bands(0).Columns("IdProdNom").Hidden = True
            .DisplayLayout.Bands(0).Columns("IdPeriodo").Hidden = True
            .DisplayLayout.Bands(0).Columns("FInicial").Hidden = True
            .DisplayLayout.Bands(0).Columns("idcelula").Hidden = True
            .DisplayLayout.Bands(0).Columns("FFinal").Hidden = True
            .DisplayLayout.Bands(0).Columns("Activo").Hidden = True
            .DisplayLayout.Bands(0).Columns("IdCelula").Hidden = True
            .DisplayLayout.Bands(0).Columns("DepartamentoID").Hidden = True
            '.DisplayLayout.Bands(0).Columns("Pares").Width = 147
            .DisplayLayout.Bands(0).Columns("Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .DisplayLayout.Bands(0).Columns("Periodo").Width = 300
            .DisplayLayout.Bands(0).Columns("Celula").Width = 170
            .DisplayLayout.Bands(0).Columns("Departamento").Width = 220
        End With

        'Dim columnToSummarize As UltraGridColumn = grdProduccionCelula.DisplayLayout.Bands(0).Columns("Pares")
        'Dim summary As SummarySettings = grdProduccionCelula.DisplayLayout.Bands(0).Summaries.Add("TOTAL PARES", SummaryType.Sum, columnToSummarize)
        'grdProduccionCelula.DisplayLayout.Bands(0).SummaryFooterCaption = "Pares totales:"
        'summary.DisplayFormat = "{0}"
        'summary.Appearance.TextHAlign = HAlign.Right


    End Sub

    Private Sub grdProduccionCelula_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdProduccionCelula.ClickCell
        Dim row As UltraGridRow = grdProduccionCelula.ActiveRow
        If row.IsFilterRow Then Return
        IdProduccion = CInt(row.Cells("IdProdNom").Text)
        IdPeriodo = CInt(row.Cells("IdPeriodo").Text)
        idcelula = CInt(row.Cells("IdCelula").Text)
        FechaInicial = CDate(row.Cells("FInicial").Value)
        FechaFinal = CDate(row.Cells("FFinal").Value)
        Activo = CStr(row.Cells("Activo").Value)
        IdDepartamento = CInt(row.Cells("DepartamentoID").Value)
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim formaAgregar As New AltaConfigProduccionBandaForm
        formaAgregar.StartPosition = FormStartPosition.CenterScreen
        formaAgregar.IdNave = cmbNave.SelectedValue
        formaAgregar.AgregarOEditar = True
        formaAgregar.ShowDialog()
        TablaProduccionPorBanda()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If idcelula = 0 And IdProduccion = 0 Then
            Dim FormaError As New Tools.ErroresForm
            FormaError.mensaje = "Selecciona un registro para poder editar"
            FormaError.StartPosition = FormStartPosition.CenterScreen
            FormaError.ShowDialog()
        ElseIf Activo <> "A" Then
            Dim FormaError As New Tools.ErroresForm
            FormaError.mensaje = "Solo se pueden editar registros del periodo activo"
            FormaError.StartPosition = FormStartPosition.CenterScreen
            FormaError.ShowDialog()
        Else
            Dim formaAgregar As New AltaConfigProduccionBandaForm
            formaAgregar.StartPosition = FormStartPosition.CenterScreen
            formaAgregar.IdNave = IdNave
            formaAgregar.IdCelula = idcelula
            formaAgregar.IdProduccion = IdProduccion
            formaAgregar.IdPeriodo = IdPeriodo
            formaAgregar.fechainicial = FechaInicial
            formaAgregar.fechafinal = FechaFinal
            formaAgregar.periodo = cmbPeriodo.SelectedText
            formaAgregar.IdDepartamento = IdDepartamento

            formaAgregar.AgregarOEditar = False
            formaAgregar.ShowDialog()
            TablaProduccionPorBanda()

        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If cmbNave.SelectedIndex = 0 Then
            Dim formaAlerta As New Tools.AdvertenciaForm
            formaAlerta.mensaje = "Selecciona una nave para poder consultar"
            formaAlerta.StartPosition = FormStartPosition.CenterScreen
            formaAlerta.ShowDialog()
            lblNave.ForeColor = Color.Red
        Else
            lblNave.ForeColor = Color.Black
        End If
        TablaProduccionPorBanda()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbMotivos.Height = 37
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbMotivos.Height = 97
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdProduccionCelula.DataSource = Nothing
        ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        ComboPeriodosNominaSinFiltroDescendentePeriodoActivo(cmbPeriodo, cmbNave.SelectedValue)
        IdProduccion = 0
        IdNave = 0
        IdPeriodo = 0
        idcelula = 0
        IdDepartamento = 0
        Activo = ""
    End Sub

    Private Sub grdProduccionCelula_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdProduccionCelula.DoubleClickCell
        Consulta = True

        Dim formaAgregar As New AltaConfigProduccionBandaForm
        formaAgregar.StartPosition = FormStartPosition.CenterScreen
        formaAgregar.StartPosition = FormStartPosition.CenterScreen
        formaAgregar.IdNave = IdNave
        formaAgregar.IdCelula = idcelula
        formaAgregar.IdProduccion = IdProduccion
        formaAgregar.IdPeriodo = IdPeriodo
        formaAgregar.fechainicial = FechaInicial
        formaAgregar.fechafinal = FechaFinal
        formaAgregar.periodo = cmbPeriodo.SelectedText
        formaAgregar.IdDepartamento = IdDepartamento
        formaAgregar.AgregarOEditar = False
        formaAgregar.Consulta = True
        formaAgregar.ShowDialog()

        Consulta = False
    End Sub

  
    Private Sub cmbNave_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedValueChanged
        If cmbNave.SelectedIndex > 0 Then
            ComboPeriodosNominaSinFiltroDescendentePeriodoActivo(cmbPeriodo, cmbNave.SelectedValue)
        End If

    End Sub
End Class