Imports System.Data.SqlClient
Public Class PielesDA


    Public Function VerListaPieles(ByVal codigo As String, ByVal descripcion As String, ByVal nombreCorto As String, ByVal activo As Boolean, ByVal codSicy As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String

        cadena = "Select piel_pielid, piel_codigo, piel_descripcion, piel_nombrecorto, piel_codsicy, piel_activo" +
            " from Programacion.Pieles where piel_descripcion like '%" + descripcion + "%' and piel_activo='" + activo.ToString + "'"
        If (codigo <> "") Then
            cadena += " and piel_codigo like '%" + codigo + "%'"
        End If
        If (nombreCorto <> "") Then
            cadena += " and piel_nombrecorto like '%" + nombreCorto + "%'"
        End If

        If (codSicy <> "") Then
            cadena += " and piel_codsicy like '%" + codSicy + "%'"
        End If
        cadena += " ORDER BY piel_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VerCodMax() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select Max(cast(piel_codigo as int)) as 'maxcod' from Programacion.Pieles")
    End Function

    Public Function VerIdPielMax() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select Max(piel_pielid) as 'maxcod' from Programacion.Pieles")
    End Function


    Public Sub RegistrarPiel(ByVal EntidadPiel As Entidades.Pieles, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = EntidadPiel.PPielDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "nombreCorto"
        ParametroParaLista.Value = EntidadPiel.PPNombreCorto
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "codigo"
        ParametroParaLista.Value = EntidadPiel.PPielCodigo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = EntidadPiel.PPActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "codSicy"
        ParametroParaLista.Value = EntidadPiel.PPCodSicy
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("[Programacion].[SP_Alta_Piel]", ListaParametros)
    End Sub

    Public Function VerCamposPielEditar(ByVal IdPiel As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select piel_pielid, piel_descripcion, piel_nombrecorto, piel_codigo, piel_activo from Programacion.Pieles where piel_pielid=" + IdPiel.ToString + "")
    End Function

    Public Sub EditarPiel(ByVal entidadPiel As Entidades.Pieles, ByVal usuario As Int32)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = entidadPiel.PPielDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "nombreCorto"
        ParametroParaLista.Value = entidadPiel.PPNombreCorto
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = entidadPiel.PPActivo.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idPiel"
        ParametroParaLista.Value = entidadPiel.PPielId
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "codSicy"
        ParametroParaLista.Value = entidadPiel.PPCodSicy
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_Piel", ListaParametros)
    End Sub

    Public Function VerComboPiel() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select piel_pielid, piel_codigo as 'Cod', piel_descripcion from Programacion .Pieles where piel_activo ='True'")
    End Function

    Public Function VerPielGridProducto() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select pp.piel_pielid, cc.color_colorid, " +
            "(pp.piel_descripcion+' '+cc.color_descripcion) as convinacionPC, " +
            "(pp.piel_codsicy+cc.color_codsicy) as pcsicy" +
            " from Programacion.Pieles as pp " +
                                         " inner join Programacion.PielColor as pc" +
                                         " on pp.piel_pielid =pc.pcol_pielid" +
                                         " inner join Programacion.Colores as cc" +
                                         " on pc.pcol_colorid =cc.color_colorid" +
                                         " where pp.piel_activo ='true' and" +
                                         " cc.color_activo ='true' and pc.pcol_activo='true'" +
                                         " ORDER BY convinacionPC"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub registrarPielColor(ByVal idPiel As Integer, ByVal idColor As Integer)
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlParameter) From {
             New SqlParameter With {
                .ParameterName = "idPiel",
                .Value = idPiel
            },
            New SqlParameter With {
                .ParameterName = "idColor",
                .Value = idColor
            },
             New SqlParameter With {
                .ParameterName = "idUsuario",
                .Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            }
        }

        operacion.EjecutarSentenciaSP("[Programacion].[SP_Alta_PielColor]", ListaParametros)
    End Sub


    Public Function consultaDetallesColorPiel(ByVal idPiel As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select cc.color_colorid,cc.color_descripcion, cc.color_codsicy from Programacion .Pieles as pp inner join Programacion .PielColor as pc on pp.piel_pielid =pc.pcol_pielid" +
            " inner join Programacion .Colores as cc on pc.pcol_colorid =cc.color_colorid where pp.piel_pielid =" + idPiel + " and cc.color_activo ='True' and pc.pcol_activo ='True'"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub desactivarPielColor(ByVal idPiel As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlParameter) From {
             New SqlParameter With {
                .ParameterName = "idPiel",
                .Value = idPiel
            }
        }

        operacion.EjecutarSentenciaSP("[Programacion].[SP_Desactivar_Piel_Color]", ListaParametros)
    End Sub

    Public Sub EditarPielColor(ByVal idPiel As Integer, ByVal idColor As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idPiel"
        ParametroParaLista.Value = idPiel
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idColor"
        ParametroParaLista.Value = idColor
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_Piel_Color", ListaParametros)

    End Sub

    Public Function verColoresSeleccionadosPiel(ByVal idPiel As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select cc.color_colorid, cc.color_descripcion, cc.color_codsicy, cc.color_activo  from Programacion .Colores as cc" +
            " inner join Programacion .PielColor as pc on cc.color_colorid =pcol_colorid" +
            " inner join Programacion .Pieles as pp on pc.pcol_pielid =pp.piel_pielid" +
            " where pp.piel_pielid =" + idPiel + " and cc.color_activo ='True' and pc.pcol_activo='True' union all" +
            " select cc.color_colorid, cc.color_descripcion, cc.color_codsicy, null from Programacion .Colores as cc" +
            " where cc.color_colorid not in (select cc.color_colorid from Programacion .Colores as cc" +
            " inner join Programacion .PielColor as pc on cc.color_colorid =pcol_colorid" +
            " inner join Programacion .Pieles as pp on pc.pcol_pielid =pp.piel_pielid" +
            " where pp.piel_pielid =" + idPiel + " and cc.color_activo ='True' and pc.pcol_activo='True') and cc .color_activo ='True' order by cc.color_colorid"
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function validaExistenModelos(ByVal idPiel As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT a.prod_codigo, a.prod_descripcion FROM Programacion.Productos a" +
                                " INNER JOIN Programacion.ProductoEstilo b ON a.prod_productoid = b.pres_productoid" +
                                " INNER JOIN Programacion.EstilosProducto c ON b.pres_estiloid = c.espr_estiloproductoid" +
                                " WHERE a.prod_activo = 1 AND b.pres_activo = 1" +
                                " AND c.espr_pielid = " + idPiel +
                                " GROUP BY	a.prod_codigo, a.prod_descripcion "
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function verPielesRegistroRapido(ByVal idsPieles As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " pp.piel_pielid," +
                                " cc.color_colorid," +
                                " (pp.piel_descripcion + ' ' + cc.color_descripcion) AS convinacionPC," +
                             " (pp.piel_codsicy + cc.color_codsicy) AS pcsicy" +
                            " FROM Programacion.Pieles AS pp" +
                            " INNER JOIN Programacion.PielColor AS pc" +
                                " ON pp.piel_pielid = pc.pcol_pielid" +
                            " INNER JOIN Programacion.Colores AS cc" +
                                " ON pc.pcol_colorid = cc.color_colorid" +
                                    " WHERE pp.piel_activo = 1" +
                            " AND cc.color_activo = 1" +
                            " AND pc.pcol_activo = 1" +
                            " AND pp.piel_pielid NOT IN (" + idsPieles + ")"
        Return operaciones.EjecutaConsulta(cadena)
    End Function
End Class
