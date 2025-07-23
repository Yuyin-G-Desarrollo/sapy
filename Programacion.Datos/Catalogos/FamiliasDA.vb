Imports System.Data.SqlClient
Public Class FamiliasDA

    Public Function ListarFamilias(ByVal clave As String, ByVal descripcion As String, ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
       
        Dim cadena As String = "Select" +
                                " fami_familiaid, fami_codigo, fami_descripcion, fami_activo" +
                                " from Programacion.Familias" +
                                " where fami_descripcion like '%" + descripcion + "%' and fami_activo='" + activo.ToString + "'"
        If (clave <> "") Then
            cadena += " and fami_codigo like '%" + clave + "%'"
        End If
        cadena += " ORDER BY fami_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function VerIdMaximo() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT MAX(fami_familiaid) AS 'Maximo' FROM Programacion.Familias;")
    End Function

    Public Function ContadorFilas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT * FROM Programacion.Familias;")
    End Function

    Public Function ValidarRepetidos(ByVal Codigo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select" +
                                         " fami_codigo" +
                                         " from Programacion.Familias where fami_codigo='" + Codigo + "' and fami_activo='true'")
    End Function


    Public Sub RegistrarFamilia(ByVal Familia As Entidades.Familias, ByVal usuariocreo As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = Familia.PDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "codigo"
        ParametroParaLista.Value = Familia.PCodigo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = Familia.PActivo.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuariocreo
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Altas_Familias", ListaParametros)
    End Sub

    Public Function VerCodigosDisponibles() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select" +
                                         " fami_codigo" +
                                         " from Programacion.Familias" +
                                         " where fami_activo='False' and" +
                                         " fami_codigo not in (Select fami_codigo from" +
                                         " Programacion.Familias where fami_activo='True')")
    End Function

    Public Sub ModificarFamilia(ByVal EntidadFamilia As Entidades.Familias, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = EntidadFamilia.PDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = EntidadFamilia.PActivo.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "IdFamilia"
        ParametroParaLista.Value = EntidadFamilia.PIdFamilia
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Modificar_Familia", ListaParametros)

    End Sub
    Public Function VerComboFamiliaVentas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = <cadena>
               
        SELECT fapr_familiaproyeccionid,fapr_descripcion from Programacion.Familias_Proyeccion
        where fapr_activo=1
                               </cadena>
        Return operacion.EjecutaConsulta(cadena)
    End Function
    Public Function VerComboFamiliaVentas(ByVal idProducto As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = <cadena>
               SELECT
	        fp.fapr_familiaproyeccionid,
	        fp.fapr_descripcion,
	        a.pres_activo AS selectFamilia
        FROM Programacion.ProductoEstilo a
        INNER JOIN Programacion.Familias_Proyeccion fp
	        ON fp.fapr_familiaproyeccionid=a.pres_familiaproyeccionid
        WHERE a.pres_productoid = <%= idProducto %>
        AND a.pres_activo = 1
        AND fp.fapr_activo = 1
        GROUP BY	fp.fapr_familiaproyeccionid,
	        fp.fapr_descripcion,
			        a.pres_activo 
        UNION ALL SELECT
	        fp2.fapr_familiaproyeccionid,
	        fp2.fapr_descripcion,
	        0 AS selectFamilia
        FROM Programacion.Familias_Proyeccion fp2
        WHERE fp2.fapr_familiaproyeccionid NOT IN (SELECT
	        fp1.fapr_familiaproyeccionid
        FROM Programacion.ProductoEstilo a1
        INNER JOIN Programacion.Familias_Proyeccion fp1
	        ON fp1.fapr_familiaproyeccionid=a1.pres_familiaproyeccionid
        WHERE a1.pres_productoid = <%= idProducto %>
        AND a1.pres_activo = 1
        AND fp1.fapr_activo = 1)
        ORDER BY fp.fapr_familiaproyeccionid
                               </cadena>
        Return operacion.EjecutaConsulta(cadena)
    End Function
    Public Function VerComboFamilia(ByVal descripcion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select" +
                                " fami_familiaid ,fami_codigo, fami_descripcion" +
                                " from Programacion.Familias where fami_activo='true'"
        If (descripcion <> "") Then
            cadena += " and fami_descripcion like '%" + descripcion + "%'"
        End If
        cadena += " ORDER BY fami_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VerCodigoFamiliaRapido(ByVal idFam As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select" +
                                         " fami_codigo, fami_descripcion" +
                                         " from Programacion.Familias" +
                                         " where fami_familiaid =" + idFam + "")
    End Function

    Public Function validaExistenModelos(ByVal idFamilia As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT" +
                                         " prod_codigo, prod_descripcion" +
                                         " FROM Programacion.Productos" +
                                         " WHERE prod_familiaid = " + idFamilia + " and prod_activo = 1")
    End Function

    Public Function seleccionarTallasEnFamilia(ByVal idFamilia As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT talla_tallaid, talla_descripcion, t.talla_enteros," +
                                " p.pais_nombre, 1 as seleccionado" +
                        " FROM Programacion.Tallas t" +
                        " INNER JOIN Framework.Paises p" +
                            " ON t.talla_paisid = p.pais_paisid" +
                        " INNER JOIN Programacion.FamiliaTallas f" +
                            " ON t.talla_tallaid = f.fata_tallaid" +
                            " WHERE f.fata_familiaid = " + idFamilia.ToString + " AND t.talla_activo= 1 AND f.fata_activo = 1" +
                            " UNION ALL SELECT" +
                                " talla_tallaid," +
                                " talla_descripcion, t.talla_enteros," +
                                " p.pais_nombre, 0 as seleccionado" +
                        " FROM Programacion.Tallas t" +
                        " INNER JOIN Framework.Paises p" +
                            " ON t.talla_paisid = p.pais_paisid" +
                        " WHERE t.talla_tallaid NOT IN (SELECT" +
                                " f.fata_tallaid" +
                        " FROM Programacion.Tallas t" +
                        " INNER JOIN Programacion.FamiliaTallas f" +
                        " ON t.talla_tallaid = f.fata_tallaid" +
                        " WHERE f.fata_familiaid = " + idFamilia.ToString + " AND t.talla_activo= 1 AND f.fata_activo = 1)"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function ConsultaTallasEnFamilia(ByVal idFamilia As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT talla_tallaid, talla_descripcion," +
                                " p.pais_nombre, t.talla_enteros, 1 as seleccionado" +
                        " FROM Programacion.Tallas t" +
                        " INNER JOIN Framework.Paises p" +
                            " ON t.talla_paisid = p.pais_paisid" +
                        " INNER JOIN Programacion.FamiliaTallas f" +
                            " ON t.talla_tallaid = f.fata_tallaid" +
                            " WHERE f.fata_familiaid = " + idFamilia.ToString + " AND t.talla_activo= 1 AND f.fata_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub editarEstatusFamTallas(ByVal idFamilia As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE Programacion.FamiliaTallas SET fata_activo = 0 WHERE fata_familiaid=" + idFamilia.ToString
        operaciones.EjecutaSentencia(cadena)
    End Sub

    Public Sub editarFamiliaTallas(ByVal idFamilia As Int32, ByVal idTalla As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idFamilia"
        ParametroParaLista.Value = idFamilia.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTalla"
        ParametroParaLista.Value = idTalla.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuarioCreo"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_generaFamiliaTallas", ListaParametros)

    End Sub

    Public Function FamiliasTallasSeleccionarProd() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " a.fami_familiaid, a.fami_descripcion," +
                                " c.talla_tallaid, c.talla_descripcion" +
                        " FROM Programacion.Familias a" +
                        " INNER JOIN Programacion.FamiliaTallas b" +
                            " ON a.fami_familiaid = b.fata_familiaid" +
                        " INNER JOIN Programacion.Tallas c" +
                            " ON b.fata_tallaid = c.talla_tallaid" +
                                " WHERE a.fami_activo = 1 And b.fata_activo = 1" +
                        " AND c.talla_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function familiasRegistroRapido(ByVal idsFamilias As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " a.fami_familiaid, a.fami_descripcion," +
                                " c.talla_tallaid, c.talla_descripcion" +
                        " FROM Programacion.Familias a" +
                        " INNER JOIN Programacion.FamiliaTallas b" +
                            " ON a.fami_familiaid = b.fata_familiaid" +
                        " INNER JOIN Programacion.Tallas c" +
                            " ON b.fata_tallaid = c.talla_tallaid" +
                                " WHERE a.fami_activo = 1 And b.fata_activo = 1" +
                        " AND c.talla_activo = 1"
        If idsFamilias <> "" Then
            cadena += " AND a.fami_familiaid NOT IN (" + idsFamilias + ")"
            'ElseIf idsTallas <> "" Then
            '    cadena += " AND c.talla_tallaid NOT IN (" + idsTallas + ")"
        End If

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verFamiliaRegistroRapido(ByVal idFam As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                        " fami_familiaid, " +
                                        " fami_codigo," +
                                        " fami_descripcion" +
                                        " FROM Programacion.Familias" +
                                " WHERE fami_activo = 'true'" +
                                " AND fami_familiaid NOT IN (" + idFam + ")"
        Return operacion.EjecutaConsulta(cadena)
    End Function

End Class
