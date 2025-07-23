Public Class IncapacidadesReplicarBU



    Public Function PeriodoIncapacidad(ByVal FechaIncapacidad As DateTime, ByVal BD As String, ByVal Servidor As String) As Entidades.IncapacidadesReplicar
        Dim ObjDA As New Datos.IncapacidadesReplicarDA
        Dim Tabla As DataTable
        Tabla = ObjDA.PeriodoIncapacidad(FechaIncapacidad, BD, Servidor)

        Dim ObjENT As New Entidades.Incapacidades
        Dim ObjENTREP As New Entidades.IncapacidadesReplicar
        For Each row As DataRow In Tabla.Rows

            ObjENT.PIncapacidadPeriodo = row("idPeriodo")
            ObjENTREP.PIncapacidades = ObjENT
        Next
        Return ObjENTREP
    End Function
    Public Sub ReplicarIncapacidadesInsert(ByVal Incapacidades As Entidades.IncapacidadesReplicar, ByVal BD As String, ByVal Servidor As String)
        Dim ObjDA As New Datos.IncapacidadesReplicarDA
        ObjDA.ReplicarIncapacidadesInsert(Incapacidades, BD, Servidor)
    End Sub

    Public Sub ReplicarIncapacidadesInsert2(ByVal Incapacidades As Entidades.IncapacidadesReplicar, ByVal BD As String, ByVal servidor As String)
        Dim ObjDA As New Datos.IncapacidadesReplicarDA
        ObjDA.ReplicarIncapacidadesInsert2(Incapacidades, BD, servidor)
    End Sub

    Public Sub ActualizarReplicar(ByVal idIncapacidad As Integer)
        Dim ObjDA As New Datos.IncapacidadesReplicarDA
        ObjDA.ActualizarReplicar(idIncapacidad)
    End Sub

    Public Function TipoIncidenciaLista(ByVal BD As String, ByVal Servidor As String) As List(Of Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesReplicarDA
        Dim tabla As New DataTable
        TipoIncidenciaLista = New List(Of Entidades.Incapacidades)
        tabla = ObjDA.TipoIncicendia(BD, Servidor)

        For Each row As DataRow In tabla.Rows

            Dim entIncapacidadReplicar As New Entidades.Incapacidades
            entIncapacidadReplicar.PIncidenciaDescripcionNP = row("descripcion")
            entIncapacidadReplicar.PIncidenciaIDNP = row("idtipoincidencia")
            TipoIncidenciaLista.Add(entIncapacidadReplicar)
        Next

    End Function

    Public Function UltimaIncapacidad(ByVal BD As String, ByVal servidor As String) As Entidades.IncapacidadesReplicar
        Dim ObjDA As New Datos.IncapacidadesReplicarDA
        Dim Tabla As DataTable
        Tabla = ObjDA.UltimaIncapacidad(BD, servidor)

        Dim ObjENT As New Entidades.Incapacidades
        Dim ObjENTREP As New Entidades.IncapacidadesReplicar
        For Each row As DataRow In Tabla.Rows

            ObjENT.PTarjetaIncapacidadID = row("idtarjetaincapacidad")
            ObjENTREP.PIncapacidades = ObjENT
        Next
        Return ObjENTREP
    End Function


End Class
