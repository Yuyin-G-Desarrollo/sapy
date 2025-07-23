Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListaDepartamentosForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public idDepartamento As String = ""
    Public Departamento As String = ""
    Public nave As Integer = 0
    Public Configuracion As Integer = 0


    Private Sub ListaDepartamentosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListaDepartamentos()
        'ListaDepartamentosAvance()
    End Sub

    Public Sub ListaDepartamentos()
        Dim obj As New ProduccionBU
        Dim tablas As New DataTable

        tablas = obj.listaDepartamentos(nave)
        grdDepartamentos.DataSource = tablas
        disenioGrid()
    End Sub

    'Public Sub ListaDepartamentosAvance()
    '    Dim obj As New ProduccionBU
    '    Dim tablas As New DataTable

    '    tablas = obj.listaDepartamentosAvance()
    '    grdDepartamentos.DataSource = tablas
    '    disenioGrid()
    'End Sub

    Public Sub disenioGrid()
        Dim band As UltraGridBand = Me.grdDepartamentos.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        With grdDepartamentos.DisplayLayout.Bands(0)

            .Columns("Departamento").CellActivation = Activation.NoEdit
            '.Columns("ID").CellActivation = Activation.NoEdit

            '.Columns("ID").CellAppearance.TextHAlign = HAlign.Right

            '.Columns("ID").Hidden = True
            .Columns("ID departamento").Hidden = True

            .Columns("Departamento").Width = 300
            .Columns("No").Width = 30

        End With

        'With grdDepartamentos.DisplayLayout.Bands(0)
        '    .Columns("dava_IdGrupo").CellActivation = Activation.NoEdit
        '    .Columns("dava_NombreGrupo").CellActivation = Activation.NoEdit
        '    .Columns("dava_Activo").Hidden = True

        'End With

        grdDepartamentos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        obtenerValores()
    End Sub

    Private Sub grdDepartamentos_DoubleClick(sender As Object, e As EventArgs) Handles grdDepartamentos.DoubleClick
        obtenerValores()
    End Sub

    Public Sub obtenerValores()
        Try
            idDepartamento = grdDepartamentos.ActiveRow.Cells("ID departamento").Text
            If grdDepartamentos.ActiveRow.Cells("ID").Text = "" Then
                Configuracion = 0
            Else
                Configuracion = grdDepartamentos.ActiveRow.Cells("ID").Text
            End If
            Departamento = grdDepartamentos.ActiveRow.Cells("Departamento").Text
            Me.Close()

            'idDepartamento = grdDepartamentos.ActiveRow.Cells("dava_IdGrupo").Value
            'Departamento = grdDepartamentos.ActiveRow.Cells("dava_NombreGrupo").Text
            'Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class