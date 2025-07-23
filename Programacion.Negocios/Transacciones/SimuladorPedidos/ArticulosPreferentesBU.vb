Public Class ArticulosPreferentesBU

    Public Function verArticulosDisponibles(ByVal idMaestro As Int32) As DataTable
        Dim objDA As New Datos.ArticulosPreferentesDA
        Return objDA.verArticulosDisponibles(idMaestro)
    End Function

    Public Function verArticulosPreferentes(ByVal idMaestro As Int32) As DataTable
        Dim objDA As New Datos.ArticulosPreferentesDA
        Return objDA.verArticulosPreferentes(idMaestro)
    End Function

    Public Sub guardarArticulosPreferentes(ByVal idPrestilo As Int32,
                                          ByVal idSimulacion As Int32)
        Dim objDA As New Datos.ArticulosPreferentesDA
        objDA.guardarArticulosPreferentes(idPrestilo, idSimulacion)
    End Sub

    'Public Sub quitarArticuloPreferente(ByVal idPrestilo As Int32, ByVal idSimulacion As Int32)
    '    Dim objDA As New Datos.ArticulosPreferentesDA
    '    objDA.quitarArticuloPreferente(idPrestilo, idSimulacion)
    'End Sub

    Public Function verArticulosPreferentesSimulacion(ByVal idSimulacion As Int32) As DataTable
        Dim objDA As New Datos.ArticulosPreferentesDA
        Return objDA.verArticulosPreferentesSimulacion(idSimulacion)
    End Function

    Public Sub editarOrdenArticulo(ByVal idArticuloPrefID As Int32, ByVal orden As Int32)
        Dim objDA As New Datos.ArticulosPreferentesDA
        objDA.editarOrdenArticulo(idArticuloPrefID, orden)
    End Sub

    Public Sub inactivarArticuloPreferente(ByVal idArticuloPrefID As Int32)
        Dim objDA As New Datos.ArticulosPreferentesDA
        objDA.inactivarArticuloPreferente(idArticuloPrefID)
    End Sub
End Class
