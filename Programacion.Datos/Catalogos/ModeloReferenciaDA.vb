Public Class ModeloReferenciaDA
    Public Function verListaModelos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim cadena As String = "select distinct marcaSAY, ColeccionSAY,ModeloSAY 
        '                        from Programacion.vProductoEstilos_Completo where pres_activo = 1 and prod_activo = 1 and StatusId > 1
        '                        order by ModeloSAY"
        Return operacion.EjecutaConsulta("[Programacion].[SP_ModeloReferencia]")
    End Function

    Public Function verModeloreferencia(modeloReferencia As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametroLista As New SqlClient.SqlParameter
        Try
            parametroLista.ParameterName = "@ModeloReferencia"
            parametroLista.Value = modeloReferencia
            listaParametros.Add(parametroLista)

            Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ModelosReferencia]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try


    End Function
End Class
