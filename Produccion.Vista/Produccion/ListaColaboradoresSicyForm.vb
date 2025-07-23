Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Tools

Public Class ListaColaboradoresSicyForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public nave As Integer = 0
    Public idColaborador As Integer = 0
    Public colaborador As String = ""
    Public nombreCorto As String = ""
    Public Estatus As Integer = 1

    Private Sub ListaColaboradoresSicyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LlenarListaColaboradores()
        LlenarListaColaboradoresSAY()
    End Sub

    Public Sub guardarSeleccion()
        Try
            idColaborador = grdColaboradores.ActiveRow.Cells("ID colaborador").Text
            colaborador = grdColaboradores.ActiveRow.Cells("Colaborador").Text
            nombreCorto = grdColaboradores.ActiveRow.Cells("Nombre Corto").Text
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardarSeleccion()
    End Sub

    Public Sub LlenarListaColaboradores()
        Dim obj As New ProduccionBU
        Dim tabla As New DataTable
        tabla = obj.listaColaboradoresSicy(nave)
        grdColaboradores.DataSource = tabla
        disenioGrid()
    End Sub

    Public Sub LlenarListaColaboradoresSAY()
        Dim obj As New ProduccionBU
        Dim tabla As New DataTable
        tabla = obj.listaColaboradoresSAY(nave, Estatus)
        grdColaboradores.DataSource = tabla
        'If grdColaboradores.DataSource = Nothing Then
        '    objMensaje.mensaje = "No existe registo"
        '    objMensaje.ShowDialog()
        'Else
        disenioGridSAY()
        'End If

    End Sub

    Public Sub disenioGrid()
        Dim band As UltraGridBand = Me.grdColaboradores.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        With grdColaboradores.DisplayLayout.Bands(0)

            .Columns("ID colaborador").Hidden = True
            .Columns("ID puesto").Hidden = True
            .Columns("ID departamento").Hidden = True

            .Columns("Colaborador").Width = 250
            .Columns("No").Width = 30
            .Columns("Nombre Corto").Width = 100
            .Columns("Departamento").Width = 100
            .Columns("Puesto").Width = 100

            .Columns("Colaborador").CellActivation = Activation.NoEdit
            .Columns("No").CellActivation = Activation.NoEdit
            .Columns("Nombre Corto").CellActivation = Activation.NoEdit
            .Columns("Departamento").CellActivation = Activation.NoEdit
            .Columns("Puesto").CellActivation = Activation.NoEdit

        End With
        grdColaboradores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Public Sub disenioGridSAY()
        Dim band As UltraGridBand = Me.grdColaboradores.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        With grdColaboradores.DisplayLayout.Bands(0)
            .Columns("ID Colaborador").Hidden = True
            .Columns("ID departamento").Hidden = True
            .Columns("ID puesto").Hidden = True
            .Columns("nave_nombre").Hidden = True
            .Columns("nave_navesicyid").Hidden = True

            .Columns("Colaborador").Width = 250
            .Columns("No").Width = 30
            .Columns("Nombre Corto").Width = 100
            .Columns("Departamento").Width = 100
            .Columns("Puesto").Width = 100

            .Columns("Colaborador").CellActivation = Activation.NoEdit
            .Columns("No").CellActivation = Activation.NoEdit
            .Columns("Nombre Corto").CellActivation = Activation.NoEdit
            .Columns("Departamento").CellActivation = Activation.NoEdit
            .Columns("Puesto").CellActivation = Activation.NoEdit

        End With
        grdColaboradores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub
    Private Sub grdColaboradores_DoubleClick(sender As Object, e As EventArgs) Handles grdColaboradores.DoubleClick
        guardarSeleccion()
    End Sub

End Class