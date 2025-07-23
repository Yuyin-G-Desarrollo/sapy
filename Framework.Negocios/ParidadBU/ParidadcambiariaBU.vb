Public Class ParidadcambiariaBU
    Public Function cargaMoneda(ByVal idMoneda As String) As DataTable
        Dim cargaMonedaParidad As New Framework.Datos.ParidadcambiariaDA
        Return cargaMonedaParidad.cargaMoneda(idMoneda)
    End Function

    Public Sub guardaParidadMoneda(ByVal monedaID As Integer, ByVal valorParidad As String, ByVal moduloID As Integer, ByVal tipoCarga As String)
        Dim objParidadDA As New Framework.Datos.ParidadcambiariaDA
        objParidadDA.guardaParidadMoneda(monedaID, valorParidad, moduloID, tipoCarga)
    End Sub

    Public Function cargaParidad(ByVal estatus As Boolean) As DataTable
        Dim objParidadDA As New Framework.Datos.ParidadcambiariaDA
        Return objParidadDA.cargaParidad(estatus)
    End Function

    Public Function cargaModuloActualizacion() As DataTable
        Dim objParidadDA As New Framework.Datos.ParidadcambiariaDA
        Return objParidadDA.cargaModuloActualizacion()
    End Function

    Public Function cargaModuloAlta() As DataTable
        Dim objParidadDA As New Framework.Datos.ParidadcambiariaDA
        Return objParidadDA.cargaModuloAlta()
    End Function

    Public Function ModulosAlta() As DataTable
        Dim objParidadDA As New Framework.Datos.ParidadcambiariaDA
        Return objParidadDA.ModulosAlta()
    End Function

    Public Sub guardarCargaModulo(ByVal moduloID As Int32, ByVal tipoCarga As Boolean)
        Dim objParidadDA As New Framework.Datos.ParidadcambiariaDA
        objParidadDA.guardarCargaModulo(moduloID, tipoCarga)
    End Sub

    Public Sub actualizaCargaModulo(ByVal moduloID As Int32, ByVal tipoCarga As Boolean)
        Dim objParidadDA As New Framework.Datos.ParidadcambiariaDA
        objParidadDA.actualizaCargaModulo(moduloID, tipoCarga)
    End Sub
    Public Function validaModuloActualizacionAutomatica(ByVal monedaID As Int32) As DataTable
        Dim objParidadDA As New Framework.Datos.ParidadcambiariaDA
        Return objParidadDA.validaModuloActualizacionAutomatica(monedaID)
    End Function
    Public Function validacionActualizacion() As DataTable
        Dim objParidadDA As New Framework.Datos.ParidadcambiariaDA
        Return objParidadDA.validacionActualizacion()
    End Function
End Class
