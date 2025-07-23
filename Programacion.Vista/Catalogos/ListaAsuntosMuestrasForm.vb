Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Net
Imports System.Web
Imports System.Text
Imports System.IO
Imports System.Runtime.Serialization.json


Public Class ListaAsuntosMuestrasForm
    Dim dtTablaAsuntos As DataTable
    Public Sub LlenarTablaAsuntosMuestras()
        Dim AsuntosMuestrasNegocios As New Programacion.Negocios.AsuntosMuestrasBU
        Dim activo As Boolean
        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If
        dtTablaAsuntos = New DataTable
        dtTablaAsuntos = AsuntosMuestrasNegocios.VerListaAsuntos(activo)
        grdListaAsuntos.DataSource = dtTablaAsuntos
        With grdListaAsuntos.DisplayLayout.Bands(0)
            .Columns("asmu_activo").Hidden = True
            .Columns("asmu_asuntoid").Header.Caption = "Código"
            .Columns("asmu_descripcion").Header.Caption = "Nombre"
            .Columns("asmu_asuntoid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("asmu_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("asmu_asuntoid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaAsuntos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaAsuntos.DisplayLayout.Bands(0).Columns("asmu_asuntoid").Width = 45
    End Sub

    'Public Sub LlenarTablaAsuntosMuestras()
    '    Dim activo As Boolean
    '    If (rdoActivo.Checked = True) Then activo = True
    '    'dtTablaAsuntos = New DataTable
    '    Dim Url As String = "http://localhost:5441/Api/AsuntoMuestra/VerListaAsuntos?Activo=" + activo.ToString
    '    Dim request As WebRequest = WebRequest.Create(Url)
    '    Dim response As WebResponse = request.GetResponse()
    '    Dim dataStream As Stream = response.GetResponseStream()
    '    Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
    '    Dim reader As New StreamReader(dataStream, encode)
    '    Dim responseFromServer As String = reader.ReadToEnd()
    '    Dim obj As New List(Of Entidades.AsuntosMuestras)()
    '    Dim ms As New MemoryStream(Encoding.Unicode.GetBytes(responseFromServer))
    '    Dim serializer As New System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.[GetType]())
    '    obj = DirectCast(serializer.ReadObject(ms), List(Of Entidades.AsuntosMuestras))
    '    ms.Close()
    '    ms.Dispose()
    '    'dtTablaAsuntos = JsonConvert.DeserializeObject(Of DataTable)(responseFromServer)
    '    reader.Close()
    '    response.Close()
    '    grdListaAsuntos.DataSource = obj


    '    'If dtTablaAsuntos.Rows.Count = 0 Then
    '    '    dtTablaAsuntos.Columns.Add("Activo")
    '    '    dtTablaAsuntos.Columns.Add("AsuntoMuestraId")
    '    '    dtTablaAsuntos.Columns.Add("Descripcion")
    '    'End If

    '    'If dtTablaAsuntos.Rows.Count > 0 Then
    '    With grdListaAsuntos.DisplayLayout.Bands(0)
    '        .Columns("Activo").Hidden = True
    '        .Columns("AsuntoMuestraId").Header.Caption = "Código"
    '        .Columns("Descripcion").Header.Caption = "Nombre"
    '        .Columns("AsuntoMuestraId").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    '        .Columns("Descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    '        .Columns("AsuntoMuestraId").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    '        .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
    '    End With
    '    grdListaAsuntos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    '    grdListaAsuntos.DisplayLayout.Bands(0).Columns("AsuntoMuestraId").Width = 20
    '    'End If

    'End Sub


    Public Sub EnviarDatosAsunto()
        Try
            Dim entidadAsuntosMuestras As New Entidades.AsuntosMuestras
            Dim fila As Int32 = grdListaAsuntos.ActiveRow.Index
            entidadAsuntosMuestras.Activo = grdListaAsuntos.Rows(fila).Cells("asmu_activo").Value
            entidadAsuntosMuestras.AsuntoMuestraId = grdListaAsuntos.Rows(fila).Cells("asmu_asuntoid").Value
            entidadAsuntosMuestras.Descripcion = grdListaAsuntos.Rows(fila).Cells("asmu_descripcion").Value.ToString
            Dim edAsuntoMuestra As New EditarAsuntoMuestraForm
            edAsuntoMuestra.recibirDatos(entidadAsuntosMuestras)
            edAsuntoMuestra.ShowDialog()
        Catch ex As Exception
            MsgBox(" Debe seleccionar un registro.")
        End Try
    End Sub

    Private Sub ListaAsuntosMuestrasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        Me.Top = 0
        Me.Left = 0
    End Sub
    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTablaAsuntosMuestras()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTablaAsuntosMuestras()
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim alAsuntosMuestras As New AltaAsuntosMuestrasForm
        alAsuntosMuestras.ShowDialog()
        LlenarTablaAsuntosMuestras()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        EnviarDatosAsunto()
        LlenarTablaAsuntosMuestras()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub
End Class