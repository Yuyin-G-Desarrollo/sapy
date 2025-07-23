Public Class HormasBU

    Public Function verListaHormas(ByVal Horma As String, ByVal idHorma As String, ByVal Activo As Boolean) As DataTable
        Dim objHorma As New Programacion.Datos.HormasDA
        Return objHorma.verListaHormas(Horma, idHorma, Activo)
    End Function

    Public Function idMaximohorma()
        Dim objHormaDA As New Programacion.Datos.HormasDA
        Return objHormaDA.idMaximoHorma
    End Function

    Public Sub guardarHorma(ByVal entidadHorma As Entidades.Hormas)
        Dim objHormaDA As New Programacion.Datos.HormasDA
        objHormaDA.guardarHorma(entidadHorma)
    End Sub

    Public Sub editarHorma(ByVal entidadHorma As Entidades.Hormas)
        Dim objHormaDA As New Programacion.Datos.HormasDA
        objHormaDA.EditarHorma(entidadHorma)
    End Sub

    Public Function verHormaId(ByVal idHorma As String) As DataTable
        Dim objHormaDA As New Programacion.Datos.HormasDA
        Return objHormaDA.verHormaId(idHorma)
    End Function

    Public Function validarExistenModelos(ByVal idHorma As String) As DataTable
        Dim objHormaDA As New Programacion.Datos.HormasDA
        Return objHormaDA.validarExistenmodelos(idHorma)
    End Function

    Public Function ValidarExisteHormaSAY(ByVal Descripcion As String) As DataTable
        Dim objHormaDA As New Programacion.Datos.HormasDA
        Return objHormaDA.ValidarExisteHorma(Descripcion)
    End Function


End Class
