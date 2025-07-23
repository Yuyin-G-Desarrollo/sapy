Public Class SubfamiliasBU

    Public Function ListarSubfamilias(ByVal clave As String, ByVal descripcion As String, ByVal activo As Boolean) As DataTable
        Dim FamiliaDatos As New Programacion.Datos.SubfamiliasDA
        Return FamiliaDatos.ListarSubfamilias(clave, descripcion, activo)
    End Function

    Public Function VerCodigosDisponibles()
        Dim FamiliaDatos As New Programacion.Datos.SubfamiliasDA
        Dim CodigosDisponibles = FamiliaDatos.VerCodigosDisponibles
        Return CodigosDisponibles
    End Function

    Public Sub RegistraSubfamilia(ByVal subfamilias As Entidades.Subfamilias, ByVal usuario As Int32)
        Dim FamiliasDatos As New Programacion.Datos.SubfamiliasDA
        FamiliasDatos.RegistrarsubFamilia(subfamilias, usuario)
    End Sub

    Public Function ValidarRepetidos(ByVal codigo As String) As DataTable
        Dim subFamDatos As New Programacion.Datos.SubfamiliasDA
        Dim ValidacionActivar = subFamDatos.ValidarRepetidos(codigo)
        Return ValidacionActivar
    End Function

    Public Sub EditarSubfamilia(ByVal EnSubfamilia As Entidades.Subfamilias, ByVal Usuario As Int32)
        Dim FamiliaDatos As New Programacion.Datos.SubfamiliasDA
        FamiliaDatos.ModificarSubfamilia(EnSubfamilia, Usuario)
    End Sub

    Public Function verComboSubamilias(ByVal descripcion As String) As DataTable
        Dim objFDA As New Programacion.Datos.SubfamiliasDA
        Return objFDA.VerComboSubfamilia(descripcion)
    End Function

    Public Function idMaxSubfamilia()
        Dim FamiliaDatos As New Programacion.Datos.SubfamiliasDA
        Return FamiliaDatos.idMaxSubfamilia
    End Function

    Public Function VerCodigoSubfamiliaRapido(ByVal idSub As String) As DataTable
        Dim objFDA As New Programacion.Datos.SubfamiliasDA
        Return objFDA.VerCodigoSubfamiliaRapido(idSub)
    End Function

    Public Function validarInactivarSub(ByVal idSub As String) As DataTable
        Dim objFDA As New Programacion.Datos.SubfamiliasDA
        Return objFDA.validarInactivarSub(idSub)
    End Function

End Class
