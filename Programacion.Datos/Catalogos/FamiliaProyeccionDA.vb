Public Class FamiliaProyeccionDA

    Public Function consultaFamiliasProyeccion(ByVal activo As Boolean) As DataTable
        Dim cadena As String = String.Empty
        Dim objDA As New Persistencia.OperacionesProcedimientos

        cadena = "SELECT" & _
                " fapr_familiaproyeccionid," & _
                " fapr_descripcion," & _
                " fapr_activo" & _
                " FROM Programacion.Familias_Proyeccion" & _
                " WHERE fapr_activo = '" & activo.ToString & "'"

        Return objDA.EjecutaConsulta(cadena)
    End Function
    Public Function getNaves() As DataTable
        Dim cadena As String = String.Empty
        Dim objDA As New Persistencia.OperacionesProcedimientos

        cadena = <cadena>
                     select nave_naveid,nave_nombre from Framework.Naves 
                 </cadena>
        Return objDA.EjecutaConsulta(cadena)
    End Function


    '' OAMB CAMBIOS (06/05/2025) - Se crea el SP de la consulta.
    Public Function getNavesDesarrolla() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Naves_ConsultarNavesDesarrollo]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''Public Function getNavesDesarrolla_ORIGINAL() As DataTable
    ''    Dim cadena As String = String.Empty
    ''    Dim objDA As New Persistencia.OperacionesProcedimientos

    ''    cadena = <cadena>
    ''                 select nave_naveid,nave_nombre from Framework.Naves where nave_desarrolla=1 ORDER by nave_nombre
    ''             </cadena>
    ''    Return objDA.EjecutaConsulta(cadena)
    ''End Function


    Public Function getClasificacion() As DataTable
        Dim cadena As String = String.Empty
        Dim objDA As New Persistencia.OperacionesProcedimientos
        cadena = <cadena>
                     select cocl_clasificacion from Programacion.ColeccionesClasificacion where cocl_activo=1 order by cocl_clasificacion
                 </cadena>
        Return objDA.EjecutaConsulta(cadena)
    End Function
End Class
