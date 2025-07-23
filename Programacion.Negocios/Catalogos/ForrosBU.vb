Public Class ForrosBU

    Public Function VerListaForros(ByVal descripcion As String, ByVal codigo As String, ByVal activo As Boolean) As DataTable
        Dim ForroDatos As New Programacion.Datos.ForrosDA
        Return ForroDatos.VerListaForros(descripcion, codigo, activo)
    End Function

    Public Function VerIdMaximoForros() As DataTable
        Dim ForroDatos As New Programacion.Datos.ForrosDA
        Return ForroDatos.VerIdMaximoForros
    End Function

    Public Function verFilasForros() As DataTable
        Dim ForroDatos As New Programacion.Datos.ForrosDA
        Return ForroDatos.verFilasForros
    End Function

    Public Sub RegistrarForro(ByVal entidadForro As Entidades.Forros, ByVal usuario As Int32)
        Dim ForroDatos As New Programacion.Datos.ForrosDA
        ForroDatos.RegistraForro(entidadForro, usuario)
    End Sub

    Public Sub EditarForro(ByVal EntidadForro As Entidades.Forros, ByVal ususario As Int32)
        Dim ForroDatos As New Programacion.Datos.ForrosDA
        ForroDatos.EditarForro(EntidadForro, ususario)
    End Sub

    Public Function verComboForros() As DataTable
        Dim objFDA As New Programacion.Datos.ForrosDA
        Return objFDA.verComboForros()
    End Function

    Public Function validaExistenModelos(ByVal idForro As String) As DataTable
        Dim objFDA As New Programacion.Datos.ForrosDA
        Return objFDA.validaExistenModelos(idForro)
    End Function

    Public Function verForrosRegistroRapido(ByVal idsForros As String) As DataTable
        Dim objFDA As New Programacion.Datos.ForrosDA
        Return objFDA.verForrosRegistroRapido(idsForros)
    End Function
End Class
