Public Class ProveedoresDA



    Public Function ListaProveedores() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select prov_proveedorid,prov_nombregenerico,prov_personaidproveedor,prov_clasificacionpersonaid from Proveedor.Proveedor where  prov_clasificacionpersonaid=19 and prov_activo=1 order by prov_nombregenerico asc"
        Return operaciones.EjecutaConsulta(Consulta)

    End Function


End Class
