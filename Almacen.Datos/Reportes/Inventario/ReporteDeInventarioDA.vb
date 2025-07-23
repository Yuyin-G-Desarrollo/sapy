Imports System.Collections.Generic
Imports System.Data.SqlClient
Public Class ReporteDeInventarioDA

    '''<comentario>
    ''' Obtiene inventario del precio base
    '''</comentario>    
    '''<retorno>Objeto DataTable</retorno>
    Public Function ConsultaDeReporteInventario() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Inventario_PrecioBase_v3]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
