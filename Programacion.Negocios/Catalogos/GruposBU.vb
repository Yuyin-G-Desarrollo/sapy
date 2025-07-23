Public Class GruposBU

    Public Function VerGrupos(ByVal idGrupo As String, ByVal descripcion As String, ByVal activo As Boolean) As DataTable
        Dim GruposDatos As New Programacion.Datos.GruposDA
        Return GruposDatos.VerGrupos(idGrupo, descripcion, activo)
    End Function

    Public Function VerFilasGruposBU() As DataTable
        Dim GrupoDatos As New Programacion.Datos.GruposDA
        Return GrupoDatos.VerFilasGrupos()
    End Function

    Public Function VerIdMaximoGrupos() As DataTable
        Dim GrupoDatos As New Programacion.Datos.GruposDA
        Return GrupoDatos.VerIdMaximoGrupos()
    End Function

    Public Sub RegistrarGrupo(ByVal entidadGrupo As Entidades.Grupos)
        Dim GrupoDatos As New Programacion.Datos.GruposDA
        GrupoDatos.RegistrarGrupo(entidadGrupo)
    End Sub

    Public Sub EditarGrupo(ByVal entidadGrupo As Entidades.Grupos, ByVal usuario As Int32)
        Dim GrupoDatos As New Programacion.Datos.GruposDA
        GrupoDatos.EditarGrupo(entidadGrupo, usuario)
    End Sub

    Public Function verComboGrupos(ByVal grupo As String) As DataTable
        Dim objGDA As New Programacion.Datos.GruposDA
        Return objGDA.verComboGrupos(grupo)
    End Function

    Public Function VerGruposPorIdentificador(ByVal idGrupo As String) As DataTable
        Dim objGDA As New Programacion.Datos.GruposDA
        Return objGDA.VerGruposPorIdentificador(idGrupo)
    End Function

    Public Function validaExistenModelos(ByVal idGrupo As String) As DataTable
        Dim objGDA As New Programacion.Datos.GruposDA
        Return objGDA.validaExistenModelos(idGrupo)
    End Function

    Public Function consultaGruposActualizarCapacidadLinea(ByVal idLinea As Int32, ByVal anio As Int32) As DataTable
        Dim objGDA As New Programacion.Datos.GruposDA
        Return objGDA.consultaGruposActualizarCapacidadLinea(idLinea, anio)
    End Function

End Class
