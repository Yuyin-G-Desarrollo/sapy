Public Class ColoresClientesBU

    Public Function ClientesCodigosEspeciales() As DataTable
        Dim ColoresClieDatos As New Programacion.Datos.ColoresClientesDA
        Return ColoresClieDatos.VerColoresClientes()
    End Function

    Public Function TablaColoresClientesListaPrecios(ByVal idCliente As Integer) As DataTable
        Dim ColoresClieDatos As New Programacion.Datos.ColoresClientesDA
        Return ColoresClieDatos.TablaColoresClientesListaPrecios(idCliente)
    End Function

    Public Function TablaColoresClientesColoresActivos(ByVal idCliente As Integer) As DataTable
        Dim ColoresClieDatos As New Programacion.Datos.ColoresClientesDA
        Return ColoresClieDatos.TablaColoresClientesColoresActivos(idCliente)
    End Function

    Public Function insertarActualizarColoresClientes(ByVal idColorCliente As Integer, ByVal idColor As Integer,
    ByVal idCliente As Integer, ByVal codigoColorCliente As String, ByVal nomColorCliente As String) As String
        Dim ColoresClieDatos As New Programacion.Datos.ColoresClientesDA
        Return ColoresClieDatos.insertarActualizarColoresClientes(idColorCliente, idColor, idCliente, codigoColorCliente, nomColorCliente)
    End Function

    Public Function getListaColores() As DataTable
        Dim obj As New Programacion.Datos.ColoresClientesDA
        Return obj.getListaColores
    End Function
    Public Function actualizarEstatusColorCliente(ByVal estatus As Boolean, ByVal idColorCliente As Integer) As DataTable
        Dim obj As New Programacion.Datos.ColoresClientesDA
        Return obj.actualizarEstatusColorCliente(estatus, idColorCliente)
    End Function

    Public Function ExisteCombinacionColorCliente(ByVal ColorID As Integer, ByVal CodigoColor As String, ByVal NombreCliente As String, ByVal ClienteID As Integer, ByVal ColorClienteID As Integer) As DataTable
        Dim obj As New Programacion.Datos.ColoresClientesDA
        Return obj.ExisteCombinacionColorCliente(ColorID, CodigoColor, NombreCliente, ClienteID, ColorClienteID)
    End Function

End Class
