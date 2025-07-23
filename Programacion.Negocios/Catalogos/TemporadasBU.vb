Public Class TemporadasBU

    Public Function verListaTemporadas(ByVal nombre As String, ByVal codigo As String, ByVal anio As String, ByVal activo As Boolean) As DataTable
        Dim objTDA As New Programacion.Datos.TemporadasDA
        Return objTDA.VerListaTemporadas(nombre, codigo, anio, activo)
    End Function

    Public Function ContarFilasTemporadas() As DataTable
        Dim objSDA As New Programacion.Datos.TemporadasDA
        Return objSDA.ContarFilas()
    End Function

    Public Function VerMaximoIdTemporada() As DataTable
        Dim objSDA As New Programacion.Datos.TemporadasDA
        Return objSDA.VeridMaximoidTemporada()
    End Function

    Public Function verCodigosDiscponibles() As DataTable
        Dim objSDA As New Programacion.Datos.TemporadasDA
        Return objSDA.verCodigosDisponibles()
    End Function

    Public Sub RegistrarTemporada(ByVal entidadTemporada As Entidades.Temporadas, ByVal usuario As Int32)
        Dim objTDA As New Programacion.Datos.TemporadasDA
        objTDA.RegistrarTemporada(entidadTemporada, usuario)
    End Sub

    Public Function validarRepetidos(ByVal codigo As String) As DataTable
        Dim objSDA As New Programacion.Datos.TemporadasDA
        Return objSDA.validarRepetidos(codigo)
    End Function

    Public Sub EditarTemporada(ByVal entidadTemporada As Entidades.Temporadas, ByVal usuario As Int32)
        Dim objTDA As New Programacion.Datos.TemporadasDA
        objTDA.EditarTemporada(entidadTemporada, usuario)
    End Sub

    Public Function verComboTemporadas(ByVal descripcion As String) As DataTable
        Dim objTDA As New Programacion.Datos.TemporadasDA
        Return objTDA.VerComboTemporada(descripcion)
    End Function

    Public Function VerTemporadaRegistroRapido(ByVal idtemp As String) As DataTable
        Dim objTDA As New Programacion.Datos.TemporadasDA
        Return objTDA.VerTemporadaRegistroRapido(idtemp)
    End Function

    Public Function ValidarExistenModelos(ByVal idtemp As String) As DataTable
        Dim objTDA As New Programacion.Datos.TemporadasDA
        Return objTDA.ValidarExistenModelos(idtemp)
    End Function

    Public Function verTemporadasRegistradas() As DataTable
        Dim ColeccionNegocios As New Programacion.Datos.TemporadasDA
        Return ColeccionNegocios.verTemporadasRegistradas
    End Function

    Public Function consultaAnioTemporada(ByVal idTemp As Int32) As DataTable
        Dim objPDA As New Programacion.Datos.TemporadasDA
        Return objPDA.consultaAnioTemporada(idTemp)
    End Function


End Class
