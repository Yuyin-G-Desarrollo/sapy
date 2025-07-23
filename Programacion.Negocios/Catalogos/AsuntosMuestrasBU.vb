Public Class AsuntosMuestrasBU
    Public Function VerListaAsuntos(ByVal activo As Boolean) As DataTable
        Dim AsuntosMuestrasDatos As New Programacion.Datos.AsuntosMuestrasDA
        Return AsuntosMuestrasDatos.VerListaAsuntos(activo)
    End Function

    Public Sub RegistrarAsunto(ByVal entidadAsuntoMuestras As Entidades.AsuntosMuestras, ByVal usuario As Int32)
        Dim AsuntosMuestrasDatos As New Programacion.Datos.AsuntosMuestrasDA
        AsuntosMuestrasDatos.RegistraAsunto(entidadAsuntoMuestras, usuario)
    End Sub

    Public Sub EditarAsuntoMuestra(ByVal EntidadAsuntoMuestra As Entidades.AsuntosMuestras, ByVal ususario As Int32)
        Dim AsuntoMuestraDatos As New Programacion.Datos.AsuntosMuestrasDA
        AsuntoMuestraDatos.EditarAsuntoMuestra(EntidadAsuntoMuestra, ususario)
    End Sub
End Class
