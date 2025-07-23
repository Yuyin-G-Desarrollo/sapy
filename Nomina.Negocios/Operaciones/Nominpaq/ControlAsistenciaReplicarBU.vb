Public Class ControlAsistenciaReplicarBU

    Public Function ListaColaboradorres(ByVal IDNAve As Integer, ByVal FechaInicio As DateTime) As List(Of Entidades.ControlAsistenciaReplicar)
        Dim ObjDA As New Datos.ControlAsistenciaReplicarDA

        Dim Tabla As New DataTable
        ListaColaboradorres = New List(Of Entidades.ControlAsistenciaReplicar)
        Tabla = ObjDA.ListaColaboradorres(IDNAve, FechaInicio)

        For Each row As DataRow In Tabla.Rows
            Dim ObjColaborador As New Entidades.Colaborador
            Dim ObjENT As New Entidades.ControlAsistenciaReplicar
            ObjColaborador.PNombre = row("codr_nombre")
            ObjColaborador.PApaterno = row("codr_apellidopaterno")
            ObjColaborador.PAmaterno = row("codr_apellidomaterno")
            If Not IsDBNull(row("codr_nominpaqID")) Then
                ObjColaborador.PColaboradoridNP = row("codr_nominpaqID")
            End If

            ObjColaborador.PColaboradorid = row("codr_colaboradorid")
            ObjENT.PColaborador = ObjColaborador
            ListaColaboradorres.Add(ObjENT)
        Next

    End Function

    Public Function IncidenciasCorteLista(ByVal PeriodoInicioID As Integer, ByVal PeriodoFinID As Integer, ByVal ColaboradorID As Integer) As List(Of Entidades.ControlAsistenciaReplicar)
        Dim ObjDA As New Datos.ControlAsistenciaReplicarDA
        Dim Tabla As New DataTable
        IncidenciasCorteLista = New List(Of Entidades.ControlAsistenciaReplicar)
        Tabla = ObjDA.IncidenciasCorteLista(PeriodoInicioID, PeriodoFinID, ColaboradorID)

        For Each row As DataRow In Tabla.Rows
            Dim ObjENT As New Entidades.ControlAsistenciaReplicar
            Dim ObjAsistencia As New Entidades.CorteChecador
            ObjENT.PPeriodoID = row("ccheck_periodo_id")
            ObjAsistencia.PRetardo_mayor = row("ccheck_retardo_mayor")
            ObjAsistencia.PRetardo_menor = row("ccheck_retardo_menor")
            ObjAsistencia.PInasistencia = row("ccheck_inasistencia")
            ObjENT.PCorteChecador = ObjAsistencia
            IncidenciasCorteLista.Add(ObjENT)
        Next
    End Function

    Public Function IncidenciasCorteDetalle(ByRef ColaboradorID As Integer, ByVal PeriodoID As Integer, ByVal TipoIncidencia As Integer) As List(Of Entidades.ControlAsistenciaReplicar)
        Dim ObjDA As New Datos.ControlAsistenciaReplicarDA

        Dim tabla As New DataTable
        IncidenciasCorteDetalle = New List(Of Entidades.ControlAsistenciaReplicar)
        tabla = ObjDA.IncidenciasCorteDetalle(ColaboradorID, PeriodoID, TipoIncidencia)

        For Each row As DataRow In tabla.Rows
            Dim ObjENT As New Entidades.ControlAsistenciaReplicar
            Dim Incidencia As New Entidades.RegistroCheck
            If Not IsDBNull(row("regcheck_normal")) Then
                Incidencia.PCheck_normal = row("regcheck_normal")
            Else
                Incidencia.PCheck_normal = "01-01-1900"
            End If

            If Not IsDBNull(row("regcheck_manual")) Then
                Incidencia.PCheck_manual = row("regcheck_manual")
            Else
                Incidencia.PCheck_manual = "01-01-1900"
            End If

            If Not IsDBNull(row("regcheck_automatico")) Then
                Incidencia.PCheck_automatico = row("regcheck_automatico")
            Else
                Incidencia.PCheck_automatico = "01-01-1900"
            End If
            Incidencia.PId = row("regcheck_id")

            ObjENT.PControlAsistenciaRegistroCheck = Incidencia
            IncidenciasCorteDetalle.Add(ObjENT)
        Next
    End Function

    Public Function FechaInicialPeriodo(ByVal periodoID As Integer)
        Dim ObjDA As New Datos.ControlAsistenciaReplicarDA
        Dim tabla As New DataTable
        tabla = ObjDA.FechaInicialPeriodo(periodoID)
        Dim objEnt As New Entidades.ControlAsistenciaReplicar

        For Each row As DataRow In tabla.Rows
            objEnt.PfechaPeriodo = row("pnom_fechafinal")
        Next
        Return objEnt
    End Function

    Public Sub ActualizarReplicar(ByVal idRegistroCheck As Integer)
        Dim ObjDA As New Datos.ControlAsistenciaReplicarDA
        ObjDA.ActualizarReplicar(idRegistroCheck)
    End Sub

    Public Function PeriodosReplicar(ByVal naveID As Integer) As DataTable
        Dim objDA As New Datos.ControlAsistenciaReplicarDA
        Return objDA.PeriodosReplicar(naveID)
    End Function


End Class
