Public Class CodigosClienteBU


    Public Function RecuperarListaCodigos_Cliente_O_Amece(ByVal FiltroCliente_o_Amece As Boolean, ByVal Filtro_Lugar As Integer, ByVal FiltroCantidad As Integer, _
                                                          ByVal IdCliente As Integer, ByVal IdListaPrecioCliente As Integer, ByVal Activo As Integer) As DataTable
        Dim objDA As New Datos.CodigosClienteDA
        RecuperarListaCodigos_Cliente_O_Amece = New DataTable

        RecuperarListaCodigos_Cliente_O_Amece = objDA.RecuperarListaCodigos_Cliente_O_Amece(FiltroCliente_o_Amece, Filtro_Lugar, _
                                                                                            FiltroCantidad, IdCliente, IdListaPrecioCliente, Activo)

        Return RecuperarListaCodigos_Cliente_O_Amece
    End Function


    Public Function comboClientes_CodigosCLiente() As DataTable
        Dim objDA As New Datos.CodigosClienteDA
        comboClientes_CodigosCLiente = objDA.comboClientes_CodigosCLiente()
        Return comboClientes_CodigosCLiente
    End Function


    Public Sub Agregar_Nuevo_CodigoCliente(ByVal CodigoCliente As Entidades.CodigosCliente)
        Dim objDA As New Datos.CodigosClienteDA
        objDA.Agregar_Nuevo_CodigoCliente(CodigoCliente)
    End Sub

    Public Sub Editar_CodigoCliente(ByVal CodigoCliente As Entidades.CodigosCliente)
        Dim objDA As New Datos.CodigosClienteDA
        objDA.Editar_CodigoCliente(CodigoCliente)
    End Sub

    Public Sub Eliminar_CodigoCliente(ByVal CodigoCliente As Entidades.CodigosCliente)
        Dim objDA As New Datos.CodigosClienteDA
        objDA.Eliminar_CodigoCliente(CodigoCliente)
    End Sub


    Public Function ValidarCodigoClienteExistente(ByVal codigo As Entidades.CodigosCliente) As Integer
        Dim objDA As New Datos.CodigosClienteDA
        Dim dtCodigoExistente As New DataTable

        dtCodigoExistente = objDA.ValidarCodigoClienteExistente(codigo)


        If dtCodigoExistente.Rows.Count = 0 Then
            ValidarCodigoClienteExistente = 0
        Else
            ValidarCodigoClienteExistente = dtCodigoExistente.Rows(0).Item(0)
        End If

        Return ValidarCodigoClienteExistente
    End Function

End Class
