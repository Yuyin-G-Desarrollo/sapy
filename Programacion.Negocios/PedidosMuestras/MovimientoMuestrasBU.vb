Public Class MovimientoMuestrasBU
    Public Function tablaLayoutEtiquetasMuestras() As DataTable
        Dim MovimientosMuestrasDA As New Programacion.Datos.MovimientosMuestrasDA
        Return MovimientosMuestrasDA.tablaLayoutEtiquetasMuestras()
    End Function

    Public Function tablaLayoutEtiquetasMuestras(ByVal etiqueta As String) As DataTable
        Dim MovimientosMuestrasDA As New Programacion.Datos.MovimientosMuestrasDA
        Return MovimientosMuestrasDA.tablaLayoutEtiquetasMuestras(etiqueta)
    End Function
    Sub EditarPedidosMuestrasPiezas(ByVal etiqueta As String, ByVal Accion As Integer, UsuarioID As Int32, ByVal idSalidaInventario As Integer)
        Dim MovimientosMuestrasDA As New Programacion.Datos.MovimientosMuestrasDA
        MovimientosMuestrasDA.EditarPedidosMuestrasPiezas(etiqueta, Accion, UsuarioID, idSalidaInventario)
        'MovimientosMuestrasDA.EditarPedidosMuestrasPiezas(etiqueta, Accion)
    End Sub

    Public Function InsertarSalidasInventario(ByVal Piezas As Integer, ByVal Motivo As String, ByVal UsuarioID As Int32) As DataTable
        Dim MovimientosMuestrasDA As New Programacion.Datos.MovimientosMuestrasDA
        Return MovimientosMuestrasDA.InsertarSalidasInventario(Piezas, Motivo, UsuarioID)
    End Function
    Public Function obtenerCedisNaves()
        Dim objDA As New Programacion.Datos.MovimientosMuestrasDA
        Return objDA.CargarCedisNaves
    End Function

End Class
