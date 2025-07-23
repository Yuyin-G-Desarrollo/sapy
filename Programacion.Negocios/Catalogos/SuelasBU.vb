Public Class SuelasBU

    Public Function verListaSuelas(ByVal descripcion As String, ByVal activo As String, ByVal codigo As String) As DataTable
        Dim objSDA As New Programacion.Datos.SuelasDA
        Return objSDA.VerListaSuelas(descripcion, activo, codigo)
    End Function

    Public Function ContarFilasSuelas() As DataTable
        Dim objSDA As New Programacion.Datos.SuelasDA
        Return objSDA.ContarFilas()
    End Function

    Public Function VerMaximoIdSuela() As DataTable
        Dim objSDA As New Programacion.Datos.SuelasDA
        Return objSDA.VeridMaximoSuela()
    End Function

    Public Sub registraSuela(ByVal entidadSuela As Entidades.Suelas, ByVal usuario As String)
        Dim objSDA As New Programacion.Datos.SuelasDA
        objSDA.RegistrarSuela(entidadSuela, usuario)
    End Sub

    Public Function verCodigosDiscponibles() As DataTable
        Dim objSDA As New Programacion.Datos.SuelasDA
        Return objSDA.verCodigosDisponibles()
    End Function

    Public Sub editarSuela(ByVal entidadSuela As Entidades.Suelas, ByVal usuario As String)
        Dim objSDA As New Programacion.Datos.SuelasDA
        objSDA.editarSuela(entidadSuela, usuario)
    End Sub

    Public Function validarRepetidos(ByVal codigo As String) As DataTable
        Dim objSDA As New Programacion.Datos.SuelasDA
        Return objSDA.validarRepetidos(codigo)
    End Function

    Public Function verComboSuelas() As DataTable
        Dim objSDA As New Programacion.Datos.SuelasDA
        Return objSDA.verComboSuelas()
    End Function

    Public Function validaExistenModelos(ByVal idSuela As String) As DataTable
        Dim objSDA As New Programacion.Datos.SuelasDA
        Return objSDA.validaExistenModelos(idSuela)
    End Function

    Public Function verSuelasRegistradasRapido(ByVal idsSuelas As String) As DataTable
        Dim objSDA As New Programacion.Datos.SuelasDA
        Return objSDA.verSuelasRegistradasRapido(idsSuelas)
    End Function


End Class
