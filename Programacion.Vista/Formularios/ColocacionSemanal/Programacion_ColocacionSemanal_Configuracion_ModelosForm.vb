Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios

Public Class Programacion_ColocacionSemanal_Configuracion_ModelosForm
    Public IdNaveSay As Integer
    Public NombreNave As String
    Public marcadosActualmente As New List(Of Integer)
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Public tabla As New DataTable
    Public Sub disenioGrid()
        With grdListadoFamilias.DisplayLayout

            .PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ExtendLastColumn
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
            .Bands(0).Columns(" ").Hidden = True
            .Bands(0).Columns("ccna_naveidsay").Hidden = True
            .Bands(0).Columns("EquivalenciaOriginal").Hidden = True
        End With
    End Sub
    Private Sub consultarFamiliasNoAsignadas()
        Dim obj As New Programacion_FamiliaNave_BU
        grdListadoFamilias.DataSource = Nothing
        Try
            Dim dtConsultaFamilias As New DataTable
            dtConsultaFamilias = obj.ObtenerFamiliasNoAsignadasPorNave(IdNaveSay)
            If dtConsultaFamilias.Rows.Count > 0 Then
                grdListadoFamilias.DataSource = dtConsultaFamilias
                disenioGrid()
            Else
                objAdvertencia.mensaje = "No existen familias para asignar a esta nave."
                objAdvertencia.ShowDialog()
                Me.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        If txtEquivalencia.Value > 0 Then
            objConfirmar.mensaje = "Se editarán " & lblNumFiltrados.Text & " modelos de la nave " & NombreNave & ".Este cambio no podrá revertirse ¿Desea continuar?"
            If objConfirmar.ShowDialog = DialogResult.OK Then
                Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
                For Each row As DataRow In tabla.Rows
                    Dim activo = 1
                    Dim equivalencia = txtEquivalencia.Value
                    Dim vNodo As XElement = New XElement("Celda")
                    vNodo.Add(New XAttribute("NaveIdSAY", row.ItemArray(0)))
                    vNodo.Add(New XAttribute("ModeloIdSay", row.ItemArray(4)))
                    vNodo.Add(New XAttribute("Equivalencia", equivalencia))
                    vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                    vXmlCeldasModificadas.Add(vNodo)
                Next
                Dim obj As New Programacion_ModeloNave_BU
                Try
                    obj.EditarModelosAsignadosPorNave(vXmlCeldasModificadas.ToString())
                    Me.DialogResult = DialogResult.OK
                    Me.Dispose()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Else
                Me.DialogResult = DialogResult.None
            End If
        Else
            objAdvertencia.mensaje = "La equivalencia debe ser mayor a 0."
            objAdvertencia.ShowDialog()
            Me.DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub Programacion_ColocacionSemanal_Configuracion_ModelosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdListadoFamilias.DataSource = tabla
        lblNumFiltrados.Text = grdListadoFamilias.Rows.Count
        disenioGrid()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub
End Class