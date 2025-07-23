Imports DevExpress.XtraGrid.Views.Base
Imports Tools
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid

Public Class DetallesCalificacionEvaluacionCalidadForm


    Dim OBJBU As New Negocios.ReporteEvaluacionCalidadNaveBU
    Public NaveId As Integer = 0
    Public Año As Integer = 0
    Public Semana As Integer = 0

    Private Sub DetallesCalificacionEvaluacionCalidadForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Año >= 2019 Then
            CrearTablaNuevoCriterioEvaluacion()
        Else
            CrearTabla()
        End If

    End Sub

    Private Sub CrearTablaNuevoCriterioEvaluacion()
        Dim dtResultado As New DataTable
        Dim dtDetallesCalificacion As New DataTable
        Dim PuntacionObtenidaIncidenciaMenor As String = String.Empty
        Dim PuntacionObtenidaIncidenciaMayor As String = String.Empty
        Dim TotalParesRechazados As String = String.Empty
        Dim PuntuacionDevolucion As String = String.Empty
        Dim MaximoDevolucionPorNave As String = String.Empty
        Dim Calificacion As String = String.Empty
        Dim CalificacionIncidenciaMenor As String = String.Empty
        Dim CalificacionIncidenciaMayor As String = String.Empty
        Dim CalificacionRechazados As String = String.Empty
        Dim CalificacionDevolucion As String = String.Empty
        Dim CalificacionDevolucionMaximoNave As String = String.Empty
        Dim Nave As String = String.Empty
        Dim IncidenciaMayor As Integer = 0
        Dim IncidenciaMenor As Integer = 0
        Dim TotalDevoluciones As Integer = 0

        Try


            dtResultado.Columns.Add("Criterio", GetType(String))
            dtResultado.Columns.Add("Resultado", GetType(String))
            dtResultado.Columns.Add("Puntación", GetType(Integer))

            dtDetallesCalificacion = OBJBU.ConsultaDetallesEvaluacionCalidad(NaveId, Año, Semana)

            If IsNothing(dtDetallesCalificacion) = False Then
                If dtDetallesCalificacion.Rows.Count > 0 Then
                    With dtDetallesCalificacion
                        PuntacionObtenidaIncidenciaMenor = .Rows(0).Item("PuntuacionIncidenciaMenor")
                        PuntacionObtenidaIncidenciaMayor = .Rows(0).Item("PuntacionIncidenciaMayor")
                        TotalParesRechazados = .Rows(0).Item("TotalParesRechazados")
                        PuntuacionDevolucion = .Rows(0).Item("PuntacionDevolucion")
                        ' MaximoDevolucionPorNave = .Rows(0).Item("PuntajeMaximoDevolucin")
                        Calificacion = .Rows(0).Item("Calificacion")
                        CalificacionIncidenciaMenor = .Rows(0).Item("CalificacionMenor")
                        CalificacionIncidenciaMayor = .Rows(0).Item("CalificacionMayor")
                        'CalificacionRechazados = .Rows(0).Item("CalificacionRechazos")
                        CalificacionDevolucion = .Rows(0).Item("CalificacionDevolucion")
                        IncidenciaMayor = .Rows(0).Item("IncidenciaMayor")
                        IncidenciaMenor = .Rows(0).Item("IncidenciaMenor")
                        TotalDevoluciones = .Rows(0).Item("TotalDevoluciones")
                        CalificacionDevolucionMaximoNave = .Rows(0).Item("DevolucionMaximoNave")
                        Nave = .Rows(0).Item("Nave")
                    End With

                End If
            End If

            lblNave.Text = Nave
            dtResultado.Rows.Add("INCIDENCIAS MENORES", IncidenciaMenor.ToString, CalificacionIncidenciaMenor)
            dtResultado.Rows.Add("INCIDENCIAS MAYORES", IncidenciaMayor.ToString, CalificacionIncidenciaMayor)
            dtResultado.Rows.Add("DEVOLUCIONES DE CLIENTES POR DEFECTO", TotalDevoluciones.ToString, CalificacionDevolucion)
            dtResultado.Rows.Add("CALIFICACIÓN", "", Calificacion.ToString)

            grdDetallesCalificacion.DataSource = dtResultado
            DiseñoGrid.DiseñoBaseGrid(viewDetallesCalidad)
            viewDetallesCalidad.Columns("Resultado").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            viewDetallesCalidad.OptionsView.ColumnAutoWidth = True
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try


    End Sub

    Private Sub CrearTabla()
        Dim dtResultado As New DataTable
        Dim dtDetallesCalificacion As New DataTable
        Dim PuntacionObtenidaIncidenciaMenor As String = String.Empty
        Dim PuntacionObtenidaIncidenciaMayor As String = String.Empty
        Dim TotalParesRechazados As String = String.Empty
        Dim PuntuacionDevolucion As String = String.Empty
        Dim MaximoDevolucionPorNave As String = String.Empty
        Dim Calificacion As String = String.Empty
        Dim CalificacionIncidenciaMenor As String = String.Empty
        Dim CalificacionIncidenciaMayor As String = String.Empty
        Dim CalificacionRechazados As String = String.Empty
        Dim CalificacionDevolucion As String = String.Empty
        Dim CalificacionDevolucionMaximoNave As String = String.Empty
        Dim Nave As String = String.Empty

        Try


            dtResultado.Columns.Add("Criterio", GetType(String))
            dtResultado.Columns.Add("Evaluación", GetType(String))
            dtResultado.Columns.Add("Resultado", GetType(String))
            dtResultado.Columns.Add("Puntación", GetType(Integer))

            dtDetallesCalificacion = OBJBU.ConsultaDetallesEvaluacionCalidad(NaveId, Año, Semana)

            If IsNothing(dtDetallesCalificacion) = False Then
                If dtDetallesCalificacion.Rows.Count > 0 Then
                    With dtDetallesCalificacion
                        PuntacionObtenidaIncidenciaMenor = .Rows(0).Item("PuntuacionIncidenciaMenor")
                        PuntacionObtenidaIncidenciaMayor = .Rows(0).Item("PuntacionIncidenciaMayor")
                        TotalParesRechazados = .Rows(0).Item("TotalParesRechazados")
                        PuntuacionDevolucion = .Rows(0).Item("PuntacionDevolucion")
                        MaximoDevolucionPorNave = .Rows(0).Item("PuntajeMaximoDevolucin")
                        Calificacion = .Rows(0).Item("Calificacion")
                        CalificacionIncidenciaMenor = .Rows(0).Item("CalificacionMenor")
                        CalificacionIncidenciaMayor = .Rows(0).Item("CalificacionMayor")
                        CalificacionRechazados = .Rows(0).Item("CalificacionRechazos")
                        CalificacionDevolucion = .Rows(0).Item("CalificacionDevolucion")
                        CalificacionDevolucionMaximoNave = .Rows(0).Item("DevolucionMaximoNave")
                        Nave = .Rows(0).Item("Nave")
                    End With

                End If
            End If

            lblNave.Text = Nave
            dtResultado.Rows.Add("INCIDENCIAS MENORES", "2 PUNTOS SI ES MENOR AL 25%", PuntacionObtenidaIncidenciaMenor.ToString, CalificacionIncidenciaMenor)
            dtResultado.Rows.Add("INCIDENCIAS MAYORES", "3 PUNTOS SI ES MENOR AL 5%", PuntacionObtenidaIncidenciaMayor.ToString, CalificacionIncidenciaMayor)
            dtResultado.Rows.Add("RECHAZOS", "3 PUNTOS SI TIENE 0 RECHAZOS", TotalParesRechazados.ToString, CalificacionRechazados)
            dtResultado.Rows.Add("DEVOLUCIONES DE CLIENTES POR DEFECTO", "2 PUNTOS SI ES MENOR A " + MaximoDevolucionPorNave.ToString, PuntuacionDevolucion.ToString, CalificacionDevolucion)
            dtResultado.Rows.Add("CALIFICACIÓN", "---", "", Calificacion.ToString)

            grdDetallesCalificacion.DataSource = dtResultado
            DiseñoGrid.DiseñoBaseGrid(viewDetallesCalidad)
            viewDetallesCalidad.Columns("Resultado").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            viewDetallesCalidad.OptionsView.ColumnAutoWidth = True
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try


    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub viewDetallesCalidad_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles viewDetallesCalidad.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        Dim CRITERIO As String = String.Empty

        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return

        Try
            Cursor = Cursors.WaitCursor


            If e.Column.FieldName = "Puntación" And e.RowHandle > 0 Then
                If e.CellValue = 0 Then
                    e.Appearance.BackColor = Color.LightCoral
                End If
            End If
            CRITERIO = viewDetallesCalidad.GetRowCellValue(e.RowHandle, "Criterio")

            If CRITERIO = "CALIFICACIÓN" Then
                e.Appearance.BorderColor = Color.Black
                e.Appearance.BackColor = Color.AliceBlue
                e.Appearance.ForeColor = Color.Black
                If e.Column.FieldName = "Puntación" Then
                    e.Appearance.BackColor = Color.MediumAquamarine
                End If
            End If




            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default

        End Try
    End Sub
End Class