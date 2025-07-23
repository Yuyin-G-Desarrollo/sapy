Imports System.Data.SqlClient
Public Class RedimencionarImagenDA

    Public Function ConsultarModelosRedimensionar(ByVal productoEstiloId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim dt As New DataTable

        Dim parametro As New SqlParameter("@ProductoEstiloId", productoEstiloId)
        listaParametros.Add(parametro)

        dt = objPersistencia.EjecutarConsultaSP("[Almacen].[SP_consulta_ModelosRedimensionarProductoEstiloId]", listaParametros)
        Return dt

    End Function

    Public Function ActualizarModelos(ByVal productoEstiloId As Integer, ByVal nombreArchivo As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@ProductoEstilo", productoEstiloId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@nombreArchivo", nombreArchivo)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Actualizar_ModelosRedimensionarProductoEstiloId]", listaParametros)

    End Function

End Class
