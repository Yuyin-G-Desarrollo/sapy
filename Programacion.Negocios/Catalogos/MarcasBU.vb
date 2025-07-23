Public Class MarcasBU
    Public Function TablaMarcas(ByVal activo As Boolean) As DataTable
        Dim MarcasDatos As New Programacion.Datos.MarcasDA
        Dim DatosMarcaReturn = MarcasDatos.MostrarMarcas(activo)
        Return DatosMarcaReturn
    End Function

    Public Function SeleccionarMaximoId() As DataTable
        Dim MarcasDatos As New Programacion.Datos.MarcasDA
        Dim IdMaximoMarca = MarcasDatos.TraerIdMarcaMAsAlto
        Return IdMaximoMarca
    End Function


    Public Function VerCodigosDisponibles()
        Dim MarcasDatos As New Programacion.Datos.MarcasDA
        Dim CodigosDisponibles = MarcasDatos.VerCodigosDisponibles
        Return CodigosDisponibles
    End Function


    Public Sub RegistrarNuevaMarca(ByVal Marca As Entidades.Marcas, ByVal usuario As Int32)
        Dim MarcaDatos As New Programacion.Datos.MarcasDA
        MarcaDatos.RegistrarNuevaMarca(Marca, usuario)
    End Sub


    Public Function ValidarRepetidos(ByVal codigo As String) As DataTable
        Dim MarcaDatos As New Programacion.Datos.MarcasDA
        Dim ValidacionActivar = MarcaDatos.ValidarRepetidos(codigo)
        Return ValidacionActivar
    End Function


    Public Sub EditarMarca(ByVal Marca As Entidades.Marcas, ByVal usuario As Int32)
        Dim MarcaDatos As New Programacion.Datos.MarcasDA
        MarcaDatos.EditarMarca(Marca, usuario)
    End Sub

    Public Function ContadorFilas() As DataTable
        Dim FamiliaDatos As New Programacion.Datos.MarcasDA
        Return FamiliaDatos.ContadorFilas
    End Function

    Public Function ComboMarcas() As DataTable
        Dim MarcaDatos As New Programacion.Datos.MarcasDA
        Return MarcaDatos.ComboMarcas()
    End Function

    Public Function VerMarcas() As DataTable
        Dim MarcaDatos As New Programacion.Datos.MarcasDA
        Return MarcaDatos.VerMarcas
    End Function

    Public Function verCodigoRegistrado(ByVal idMarca As String) As DataTable
        Dim MarcaDatos As New Programacion.Datos.MarcasDA
        Return MarcaDatos.verCodigoRegistrado(idMarca)
    End Function

    Public Function verMarcasRapido(ByVal descripcion As String) As DataTable
        Dim MarcaDatos As New Programacion.Datos.MarcasDA
        Return MarcaDatos.verMarcasRapido(descripcion)
    End Function

    Public Function validarInactivarMarca(ByVal idmarca As String) As DataTable
        Dim MarcaDatos As New Programacion.Datos.MarcasDA
        Return MarcaDatos.validarInactivarMarca(idmarca)
    End Function

    Public Function verMarcasYuyin() As DataTable
        Dim MarcaDatos As New Programacion.Datos.MarcasDA
        Return MarcaDatos.verMarcasYuyin()
    End Function

    Public Function MostrarMarcasWeb(ByVal Cliente As Boolean) As DataTable
        Dim MarcasDatos As New Programacion.Datos.MarcasDA
        Dim DatosMarcaReturn = MarcasDatos.MostrarMarcasWeb(Cliente)
        Return DatosMarcaReturn
    End Function

    Public Function ModelosLlenarComboMarcas(ByVal idcedis As Integer)
        Dim obj As New Programacion.Datos.MarcasDA
        Return obj.ModelosLlenarComboMarcas(idcedis)
    End Function

    Public Function verMarcasCedis(ByVal idcedis As Integer) As DataTable
        Dim MarcaDatos As New Programacion.Datos.MarcasDA
        Return MarcaDatos.verMarcasCedis(idcedis)
    End Function

    Public Function verMarcasCedis(ByVal descripcion As String, ByVal idcedis As Integer) As DataTable
        Dim obj As New Programacion.Datos.MarcasDA
        Return obj.verMarcasCedis(descripcion, idcedis)
    End Function

End Class
