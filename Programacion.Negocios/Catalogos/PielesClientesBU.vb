Public Class PielesClientesBU
    Public Function ClientesCodigosEspeciales() As DataTable
        Dim PielesClieDatos As New Programacion.Datos.PielesClientesDA
        Return PielesClieDatos.VerPielesClientes()
    End Function
    Public Function TablaPielesClientesListaPrecios(ByVal idCliente As Integer) As DataTable
        Dim ColoresClieDatos As New Programacion.Datos.PielesClientesDA
        Return ColoresClieDatos.TablaPielesClientesListaPrecios(idCliente)
    End Function
    Public Function TablaPielesClientesColoresActivos(ByVal idCliente As Integer) As DataTable
        Dim ColoresClieDatos As New Programacion.Datos.PielesClientesDA
        Return ColoresClieDatos.TablaPielesClientesColoresActivos(idCliente)
    End Function
    Public Function insertarActualizarPielesClientes(ByVal idPielCliente As Integer, ByVal idPiel As Integer,
    ByVal idCliente As Integer, ByVal codigoPielCliente As String, ByVal nomPielCliente As String) As String
        Dim ColoresClieDatos As New Programacion.Datos.PielesClientesDA
        Return ColoresClieDatos.insertarActualizarPielesClientes(idPielCliente, idPiel, idCliente, codigoPielCliente, nomPielCliente)
    End Function
    Public Function getListaPieles() As DataTable
        Dim obj As New Programacion.Datos.PielesClientesDA
        Return obj.getListaPieles()
    End Function
    Public Function actualizarEstatusPielCliente(ByVal estatus As Boolean, ByVal idPielCliente As Integer) As DataTable
        Dim obj As New Programacion.Datos.PielesClientesDA
        Return obj.actualizarEstatusPielCliente(estatus, idPielCliente)
    End Function

    Public Function ExisteCombinacionPielCliente(ByVal PielID As Integer, ByVal CodigoCliente As String, ByVal NombreCliente As String, ByVal ClienteID As Integer, ByVal PielClienteID As Integer) As DataTable
        Dim obj As New Programacion.Datos.PielesClientesDA
        Return obj.ExisteCombinacionPielCliente(PielID, CodigoCliente, NombreCliente, ClienteID, PielClienteID)
    End Function

End Class
