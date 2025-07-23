Imports Tools

Public Class ConfiguracionGratificacionesForm

    Private Sub ConfiguracionGratificacionesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenartabla()
    End Sub

    Public Sub llenartabla()
        Dim objBU As New Negocios.ConfiguracionGratificacionesBU
        Dim listaConfiguraciones As List(Of Entidades.ConfiguracionGratificaciones)
        listaConfiguraciones = objBU.ListaConfiguracionGratificacion()
        For Each objeto As Entidades.ConfiguracionGratificaciones In listaConfiguraciones
            AgregarFila(objeto)
        Next

    End Sub


    Public Sub AgregarFila(ByVal configuracion As Entidades.ConfiguracionGratificaciones)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow






        celda = New DataGridViewTextBoxCell
        celda.Value = configuracion.PNaveNombre.PNombre.ToUpper
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = configuracion.PAutorizaGerente
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = configuracion.PAutorizaDirector
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = configuracion.PconNaveId
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = configuracion.PNaveNombre.PNaveId
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = configuracion.PApareceEnReportes
        fila.Cells.Add(celda)




        grdConfiguracionNaves.Rows.Add(fila)

    End Sub

    Public Sub InsertarInformacion()
        Dim objBU As New Negocios.ConfiguracionGratificacionesBU
        Dim Configuraciones As New Entidades.ConfiguracionNaveNomina

        Dim Gerente, Director, Reporte As Boolean
        Dim Nave As Int32

        Dim Indice As Int32 = 0

        For Each row As DataGridViewRow In grdConfiguracionNaves.Rows



            Gerente = grdConfiguracionNaves.Rows(Indice).Cells(1).Value
            Director = grdConfiguracionNaves.Rows(Indice).Cells(2).Value
            Nave = grdConfiguracionNaves.Rows(Indice).Cells(4).Value
            Reporte = grdConfiguracionNaves.Rows(Indice).Cells(5).Value

            If grdConfiguracionNaves.Rows(Indice).Cells(3).Value > 0 Then

                objBU.UpdateConfiguracionGratificacion(Gerente, Director, grdConfiguracionNaves.Rows(Indice).Cells(3).Value, grdConfiguracionNaves.Rows(Indice).Cells(5).Value)

            Else
                objBU.InsertarConfiguracionGratificacion(Gerente, Director, Nave, Reporte)
            End If
            Indice += 1
        Next



    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        InsertarInformacion()
        Dim Exito As New ExitoForm
        Exito.mensaje = "Guadado Correctamente"
        Exito.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class