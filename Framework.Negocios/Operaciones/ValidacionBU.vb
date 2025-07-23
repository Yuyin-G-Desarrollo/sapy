Public Class ValidacionBU

    Public Function Usuario_Validacion(usuarioID As Integer, tipoValidacion As Integer) As Boolean

        Dim ValidacionDA As New Datos.ValidacionDA
        Dim tabla As New DataTable
        tabla = ValidacionDA.Usuario_Validacion(usuarioID, tipoValidacion)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If



    End Function

    Public Function Cliente_Info_Obligatoria_Completa(personaID As Integer) As Boolean

        Dim ValidacionDA As New Datos.ValidacionDA
        Dim tabla As New DataTable
        tabla = ValidacionDA.Cliente_Info_Obligatoria_Completa(personaID)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Validacion_Cliente(clienteID As Integer, TipoValidacion As Integer) As DataTable

        Dim ValidacionDA As New Datos.ValidacionDA

        Return ValidacionDA.Validacion_Cliente(clienteID, TipoValidacion)

    End Function

    Public Function Validacion_InformacionCliente(clienteID As Integer) As DataTable

        Dim ValidacionDA As New Datos.ValidacionDA

        Return ValidacionDA.Validacion_InformacionCliente(clienteID)

    End Function
    Public Function Datos_TablaValidacion_Cliente(clienteID As Integer, TipoValidacion As Integer) As DataTable

        Dim ValidacionDA As New Datos.ValidacionDA

        Return ValidacionDA.Datos_TablaValidacion_Cliente(clienteID, TipoValidacion)

    End Function

    Public Function verifica_Pedidos_Pendientes(clienteID As Integer) As Boolean

        Dim ValidacionDA As New Datos.ValidacionDA
        Dim tabla As New DataTable
        tabla = ValidacionDA.verifica_Pedidos_Pendientes(clienteID)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function verifica_Saldo_Pendiente(clienteID As Integer) As Boolean

        Dim ValidacionDA As New Datos.ValidacionDA
        Dim tabla As New DataTable
        tabla = ValidacionDA.verifica_Saldo_Pendiente(clienteID)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
