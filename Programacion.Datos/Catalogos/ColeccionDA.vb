Imports System.Data.SqlClient
Public Class ColeccionDA
    Public Function LlenardatosMarcaColeccion(ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = <cadena>
            SELECT
	        c.cole_coleccionid,
	        c.cole_descripcion,
	        c.cole_temporadaid,
	        t.temp_nombre,
	        c.cole_Anio,
	        STUFF(
            (SELECT DISTINCT CAST(',' AS varchar(MAX)) + nave_nombre
            FROM Programacion.Colecciones c1 inner JOIN
            Programacion.ColeccionMarca cm ON c1.cole_coleccionid=cm.coma_coleccionid 
            inner join Framework.Naves on cm.coma_idnavedesarrolla=nave_naveid
            where c1.cole_coleccionid=c.cole_coleccionid
            FOR XML PATH('')
            ), 1, 1, '') as 'Nave(s) Desarrolla'
            FROM Programacion.Colecciones c
            JOIN Programacion.Temporadas t
	            ON c.cole_temporadaid = t.temp_temporadaid
            WHERE c.cole_activo = '<%= activo %>'
            ORDER BY c.cole_descripcion
                               </cadena>
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function LlenarDatosLotesenProceso(ByVal idColeccion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtlotesEnproceso As DataTable

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idColeccion"
        ParametroParaLista.Value = idColeccion
        ListaParametros.Add(ParametroParaLista)


        Return operacion.EjecutarConsultaSP("Programacion.SP_LotesenProceso", ListaParametros)

    End Function


    '' OAMB CAMBIOS (06/05/2025) - Se crea el SP de la consulta.
    Public Function LlenarDatosMarcaColeccionDetalle(ByVal Activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As SqlParameter
        Try

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Activo"
            ParametroParaLista.Value = Activo
            ListaParametros.Add(ParametroParaLista)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Coleccion_ConsultarColecciones]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''Public Function LlenarDatosMarcaColeccionDetalle_ORIGINAL(ByVal activo As Boolean) As DataTable
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim cadena As String = <cadena>
    ''                               SELECT
    ''                             c.cole_coleccionid,
    ''                             c.cole_descripcion,
    ''                             m.marc_descripcion,
    ''                             c.cole_temporadaid,
    ''                             t.temp_nombre,
    ''                             c.cole_Anio,
    ''                             cm.coma_clienteid,
    ''                             cl.clie_nombregenerico,
    ''				 STUFF(
    ''                    (SELECT CAST(',' AS varchar(MAX)) + nave_nombre
    ''                    FROM Programacion.Colecciones c1 inner JOIN
    ''                    Programacion.ColeccionMarca cm ON c1.cole_coleccionid=cm.coma_coleccionid 
    ''                    inner join Framework.Naves on cm.coma_idnavedesarrolla=nave_naveid
    ''                    where c1.cole_coleccionid=c.cole_coleccionid
    ''                    FOR XML PATH('')
    ''                    ), 1, 1, '') as 'Nave(s) Desarrolla'
    ''                     FROM Programacion.Colecciones c
    ''                     JOIN Programacion.ColeccionMarca cm
    ''                     ON c.cole_coleccionid = cm.coma_coleccionid
    ''                     JOIN Programacion.Marcas m
    ''                     ON cm.coma_marcaid = m.marc_marcaid
    ''                     JOIN Programacion.Temporadas t
    ''                     ON c.cole_temporadaid = t.temp_temporadaid
    ''                     LEFT JOIN Cliente.Cliente cl on cm.coma_clienteid=cl.clie_clienteid
    ''                     WHERE c.cole_activo = '<%= activo %>' AND cm.coma_activo = 1
    ''                     ORDER BY c.cole_descripcion, m.marc_descripcion
    ''                           </cadena>
    ''    Return operacion.EjecutaConsulta(cadena)
    ''End Function


    Public Function VerIdMasAltocColeccion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select max(cole_coleccionid) as 'IdColeccion' from Programacion.Colecciones")
    End Function

    Public Sub inactivarRelacionColeccionMarca(ByVal idColeccion As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE Programacion.ColeccionMarca SET coma_activo=0 WHERE coma_coleccionid =" + idColeccion.ToString
        operaciones.EjecutaSentencia(cadena)
    End Sub

    Public Function MAXExistenciaMarcasoleccion(ByVal idMarca As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "Select Max(cm.coma_codigo) as 'codigo'" +
                                         " from  Programacion.ColeccionMarca as cm" +
                                         " where cm.coma_marcaid=" + idMarca.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function ValidaMarcaColeccionEditar(ByVal Marcaid As Int32, ByVal coleccionid As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT coma_activo FROM Programacion.ColeccionMarca WHERE coma_marcaid = " + Marcaid.ToString + " AND coma_coleccionid = " + coleccionid.ToString + " AND coma_activo = 'true' ")
    End Function

    Public Function VerComboColecciones(ByVal idMarca As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select cl.cole_descripcion" +
            " from Programacion.Colecciones as cl" +
            " inner join Programacion.ColeccionMarca as cm" +
            " on cl.cole_coleccionid = cm.coma_coleccionid" +
            " where cl.cole_activo ='True'"
        If (idMarca <> "") Then
            cadena += " and cm.coma_marcaid in (" + idMarca + ")"
        End If

        cadena += "and cm.coma_activo = 1 group by cl.cole_descripcion" +
            " order by cl.cole_descripcion"
        Return operacion.EjecutaConsulta(cadena)

    End Function

    Public Function filtromultipleColeccion(ByVal idMarca As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select cl.cole_coleccionid, cm.coma_codigo, cl.cole_descripcion" +
            " from Programacion.Colecciones as cl" +
            " inner join Programacion .ColeccionMarca as cm" +
            " on cl.cole_coleccionid =cm.coma_coleccionid" +
            " where cl.cole_activo ='True'"
        If (idMarca <> "0" And idMarca <> "") Then
            cadena += " and cm.coma_marcaid in(" + idMarca + ")"
        End If
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validarInactivacionCM(ByVal idmarca As String, ByVal idcoleccion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT prod_productoid, prod_codigo, prod_descripcion FROM Programacion.Productos WHERE prod_coleccionid = " + idcoleccion + " AND prod_activo=1"
        If idmarca <> "" Then
            cadena += " AND prod_marcaid = " + idmarca + ""
        End If
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function LlenardatosColeccionWEB(ByVal marcaID As String, ByVal coleDescripcion As String, ByVal activo As Boolean, ByVal Cliente As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim cadena As String = "select c.cole_coleccionid, cm.coma_codigo, c.cole_descripcion, cm.coma_codigosicy, cm.coma_activo, m.marc_descripcion, t.temp_nombre" +
                                           " from Programacion.Colecciones as c inner join Programacion.ColeccionMarca as cm on c.cole_coleccionid=cm.coma_coleccionid" +
                                           " inner join Programacion.Marcas as m on cm.coma_marcaid=m.marc_marcaid " +
                                           " JOIN Programacion.Temporadas t ON c.cole_temporadaid = t.temp_temporadaid"
        cadena += " where c.cole_descripcion like '%" + coleDescripcion + "%' "
        cadena += " and c.cole_activo='" + activo.ToString + "' "
        cadena += " and m.marc_activo = 1 "
        cadena += " and cm.coma_activo = 1"

        If (marcaID <> "") Then
            cadena += " and m.marc_marcaid in (" + marcaID + ")"
        Else
            cadena += " and m.marc_marcaid in (2, 3, 4)"
        End If
        cadena += " and m.marc_esCliente='" + Cliente.ToString + "' ORDER BY c.cole_descripcion, m.marc_descripcion"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    ' ''Correcciones 12/09/2014 
    Public Function verColeccionesAnio(ByVal anio As Int32, ByVal idMarca As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " c.cole_coleccionid," +
                                " cm.coma_codigo," +
                                " c.cole_descripcion," +
                                " m.marc_marcaid," +
                                " m.marc_descripcion," +
                                " m.marc_escliente, m.marc_codigosicy" +
                                " FROM Programacion.Colecciones AS c" +
                                " JOIN Programacion.ColeccionMarca cm" +
                                " ON c.cole_coleccionid = cm.coma_coleccionid" +
                                " JOIN Programacion.Marcas m" +
                                " ON cm.coma_marcaid = m.marc_marcaid" +
                                " WHERE c.cole_Anio = " + anio.ToString +
                                " AND m.marc_marcaid = " + idMarca.ToString +
                                " ORDER BY m.marc_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function InsertarColeccion(ByVal Coleccion As String, ByVal anio As Int32, ByVal activo As Boolean, ByVal temporadaId As Int32, ByVal EtiquetaLengua As Boolean, Codigo As String) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtNuevaColeccion As DataTable
        Dim idNuevo As Int32
        Dim cadena As String = ""
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@coleccion"
        ParametroParaLista.Value = Coleccion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@anio"
        ParametroParaLista.Value = anio
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activo"
        ParametroParaLista.Value = activo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTemporada"
        ParametroParaLista.Value = temporadaId
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@EtiquetaLengua"
        ParametroParaLista.Value = EtiquetaLengua
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@CodigoColeccion"
        ParametroParaLista.Value = Codigo
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Alta_Coleccion", ListaParametros)

        cadena = "SELECT" +
                " MAX(cole_coleccionid) as MAXID" +
                " FROM Programacion.Colecciones" +
                " WHERE cole_descripcion ='" + Coleccion + "'"
        dtNuevaColeccion = operacion.EjecutaConsulta(cadena)
        idNuevo = dtNuevaColeccion.Rows(0).Item("MAXID").ToString
        Return idNuevo
    End Function

    Public Function ConsultarEtiquetaColeccion(ByVal ColeccionID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadenaSQL As String
        Dim dt As DataTable
        Try
            cadenaSQL = "select count(etec_etiquetaespecialcoleccionid) " +
                " from Programacion.TBL_Etiquetas_Coleccion where etec_coleccionid=" + ColeccionID.ToString + " And etec_activo=1 "
            dt = operacion.EjecutaConsulta(cadenaSQL)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub InsertarColeccionEtiquetaEspecial(ByVal TipoEtiqueta As Integer, ByVal ColeccionID As Integer, ByVal activo As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As SqlParameter

        Try
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@TipoEtiqueta"
            ParametroParaLista.Value = TipoEtiqueta
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@ColeccionID"
            ParametroParaLista.Value = ColeccionID
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Activo"
            ParametroParaLista.Value = activo
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@UsuarioCreo"
            ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@UsuarioMoDIfico"
            ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            ListaParametros.Add(ParametroParaLista)

            operacion.EjecutarConsultaSP("[Programacion].[SP_Coleccion_InsertarEtiqueta]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub InsertarColeccionMarca(ByVal idColeccion As Int32, ByVal idMarca As Int32,
                                      ByVal codigo As String, ByVal codigoSicy As String,
                                      ByVal activo As Boolean, ByVal anio As Int32,
                                      ByVal idCliente As Int32, ByVal idMarcYuyin As String,
                                      ByVal descripcionColeccionYuyin As String,
                                      ByVal idFamiliaProyeccion As String, ByVal idNaveDesarrolla As Integer,
                                      ByVal clasificacion As String)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idColeccion"
        ParametroParaLista.Value = idColeccion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@IdMarca"
        ParametroParaLista.Value = idMarca
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@codigo"
        ParametroParaLista.Value = codigo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@CodigoSicy"
        ParametroParaLista.Value = codigoSicy
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activo"
        ParametroParaLista.Value = activo.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@anio"
        ParametroParaLista.Value = anio
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idCliente"
        If idCliente = 0 Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = idCliente
        End If
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idMarcYuyin"
        If idMarcYuyin = "0" Or idMarcYuyin = "" Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = idMarcYuyin
        End If
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@descripcionColeccionYuyin"
        If descripcionColeccionYuyin.Trim = "" Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = descripcionColeccionYuyin.Trim
        End If
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idFamiliaProyeccion"
        If idFamiliaProyeccion = "0" Or idFamiliaProyeccion = "" Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = idFamiliaProyeccion
        End If
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idNaveDesarrolla"
        ParametroParaLista.Value = idNaveDesarrolla
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@clasificacion"
        ParametroParaLista.Value = clasificacion
        ListaParametros.Add(ParametroParaLista)


        operacion.EjecutarSentenciaSP("Programacion.SP_Alta_ColeccionMarca", ListaParametros)
    End Sub

    Public Function consultaMarcaRelacionColeccion(ByVal IdColeccion As Int32, ByVal idTemporada As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@IdColeccion"
        ParametroParaLista.Value = IdColeccion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTemporada"
        ParametroParaLista.Value = idTemporada
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_Consulta_ColeccionMarca2", ListaParametros)
    End Function

    Public Function VerColeccion(ByVal idColeccion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "Select" +
                            " cole_coleccionid," +
                            " cole_descripcion," +
                            " cole_activo," +
                            " cole_Anio," +
                            " cole_temporadaid," +
                            " t.temp_nombre," +
                            " cole_etiquetalengua" +
                    " FROM Programacion.Colecciones c" +
                    " JOIN Programacion.Temporadas t" +
                        " On c.cole_temporadaid = t.temp_temporadaid" +
                            " WHERE cole_coleccionid = " + idColeccion.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub EditarColeccion(ByVal idColeccion As Int32, ByVal descripcion As String, ByVal activoColeccion As Boolean, ByVal anio As Int32, ByVal idTemporada As Int32, EtiquetaLengua As Boolean)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idColeccion"
        ParametroParaLista.Value = idColeccion.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@descripcion"
        ParametroParaLista.Value = descripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activoColeccion"
        ParametroParaLista.Value = activoColeccion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@anio"
        ParametroParaLista.Value = anio.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTemporada"
        ParametroParaLista.Value = idTemporada.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@cole_EtiquetaLengua"
        ParametroParaLista.Value = EtiquetaLengua
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_Coleccion", ListaParametros)
    End Sub

    Public Sub EditarColeccionDetalle(ByVal idColeccion As Int32, ByVal idMarca As String,
                                      ByVal activoRelacion As Boolean, ByVal codigo As String,
                                      ByVal codSicy As String, ByVal existe As Int32,
                                      ByVal idCliente As Int32, ByVal idMarcYuyin As String,
                                      ByVal descripcionColeccionYuyin As String,
                                      ByVal idFamiliaProyeccion As String)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idColeccion"
        ParametroParaLista.Value = idColeccion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idMarca"
        ParametroParaLista.Value = idMarca
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activoRelacion"
        ParametroParaLista.Value = activoRelacion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@codigo"
        ParametroParaLista.Value = codigo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@codSicy"
        ParametroParaLista.Value = codSicy
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@existe"
        ParametroParaLista.Value = existe
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idCliente"
        If idCliente = 0 Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = idCliente
        End If
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idMarcYuyin"
        If idMarcYuyin = "0" Or idMarcYuyin = "" Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = idMarcYuyin
        End If
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@descripcionColeccionYuyin"
        If descripcionColeccionYuyin = "" Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = descripcionColeccionYuyin
        End If
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idFamiliaProyeccion"
        If idFamiliaProyeccion = "0" Or idFamiliaProyeccion = "" Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = idFamiliaProyeccion
        End If
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_Coleccion_Detalle", ListaParametros)
    End Sub

    Public Function verColeccionGridProducto(ByVal idMarca As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = String.Empty
        cadena = "Select" +
                " cc.cole_coleccionid," +
                " SUBSTRING(CAST(cc.cole_Anio As varchar(4)), 4, 1) + CAST(cm.coma_codigo As varchar(2)) As CODIGO," +
                " cc.cole_descripcion," +
                " cm.coma_codigosicy," +
                " cc.cole_Anio," +
                " isnull(cm.coma_familiaproyeccionid,0) 'coma_familiaproyeccionid'," +
                " isnull(fapr_descripcion,'')  'fapr_descripcion'" +
                " FROM Programacion.Colecciones AS cc" +
                " INNER JOIN Programacion.ColeccionMarca AS cm" +
                " ON cc.cole_coleccionid = cm.coma_coleccionid" +
                " left join Programacion.Familias_Proyeccion on cm.coma_familiaproyeccionid=fapr_familiaproyeccionid "

        If (idMarca <> "") Then
            cadena += " WHERE cm.coma_marcaid =" + idMarca
        Else
            cadena += " WHERE cm.coma_marcaid = 0"
        End If

        cadena += " AND cm.coma_activo=1 AND cc.cole_Anio IS NOT NULL" +
                  " ORDER BY cc.cole_descripcion"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verCodigoColeccionRegistroRapido(ByVal idCole As Int32, ByVal idMarc As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " SUBSTRING(CAST(cc.cole_Anio AS varchar(4)), 4, 1) + CAST(cm.coma_codigo AS varchar(4)) as CODIGO," +
                                " cm.coma_codigosicy," +
                                " cc.cole_descripcion," +
                                " cc.cole_Anio " +
                                " FROM Programacion.Colecciones AS cc" +
                                " INNER JOIN Programacion.ColeccionMarca AS cm" +
                                " ON cc.cole_coleccionid = cm.coma_coleccionid" +
                                " WHERE coma_coleccionid = " + idCole.ToString +
                                " AND coma_marcaid = " + idMarc.ToString +
                                " AND cc.cole_activo = 1"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validarExistenciaColeccion(ByVal codColeccion As String, ByVal idMarca As Int32, ByVal ColeccionID As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                            " cm.coma_coleccionid," +
                            " cm.coma_codigosicy," +
                            " cc.cole_descripcion," +
                            " SUBSTRING(CAST(cc.cole_Anio AS varchar(4)), 4, 1) + CAST(cm.coma_codigo AS varchar(2)) AS CODIGO," +
                            " cc.cole_Anio," +
                            " cc.cole_temporadaid" +
                            " FROM Programacion.Colecciones AS cc" +
                            " INNER JOIN Programacion.ColeccionMarca AS cm" +
                            " ON cc.cole_coleccionid = cm.coma_coleccionid" +
                            " WHERE coma_marcaid = " + idMarca.ToString +
                            " AND SUBSTRING(CAST(cc.cole_Anio AS varchar(4)), 4, 1) + CAST(cm.coma_codigo AS varchar(2)) = '" + codColeccion + "'" +
                            " AND cc.cole_coleccionid = " + ColeccionID.ToString +
                            " AND coma_activo = 1" +
                            " AND cc.cole_Anio IS NOT NULL"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verConsecutivoCodigo(ByVal marcaId As Int32, ByVal coleId As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                    " MAX(prod_consecutivo) AS 'ctvo'" +
                    " FROM Programacion.Productos AS p" +
                    " JOIN Programacion.Colecciones c" +
                    " ON p.prod_coleccionid=c.cole_coleccionid" +
                    " WHERE prod_marcaid = " + marcaId.ToString +
                    " AND prod_coleccionid = " + coleId.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function contarEstatusProductosColecciones(ByVal idColeccion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
        " p.prod_productoid," +
        " p.prod_descripcion," +
        " c.cole_coleccionid," +
        " c.cole_descripcion," +
        " pe.pres_estatus," +
        " pe.pres_estatus," +
        " st.stpr_descripcion" +
        " FROM Programacion.Productos p" +
        " JOIN Programacion.ProductoEstilo pe" +
        " ON p.prod_productoid = pe.pres_productoid" +
        " JOIN Programacion.Colecciones c" +
        " ON p.prod_coleccionid = c.cole_coleccionid" +
        " JOIN Programacion.EstatusProducto st" +
        " ON pe.pres_estatus=st.stpr_productoStatusId" +
        " WHERE c.cole_coleccionid=" + idColeccion.ToString + " AND pres_estatus IN (3, 4, 5, 6)"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function productosEditarCodigo(ByVal idColeccion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                " prod_productoid, prod_codigo, prod_marcaid" +
                " FROM Programacion.Productos WHERE prod_coleccionid=" + idColeccion.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub editarProductosAfectadosCambioAnio(ByVal idProducto As Int32, ByVal codNuevo As String, ByVal idTemporada As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idProducto"
        ParametroParaLista.Value = idProducto.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@codigo"
        ParametroParaLista.Value = codNuevo
        ListaParametros.Add(ParametroParaLista)
        'cadena += " order by c.cole_descripcion ASC"
        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTemporada"
        ParametroParaLista.Value = idTemporada.ToString
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_EditarAnioColeccionProductos", ListaParametros)
    End Sub

    Public Function consultarConsecutivos(ByVal idMarca As Int32, ByVal idColeccion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " p.prod_productoid, p.prod_consecutivo" +
                                " FROM Programacion.Productos AS p" +
                                " JOIN Programacion.Colecciones c" +
                                " ON p.prod_coleccionid = c.cole_coleccionid" +
                                " WHERE prod_marcaid = " + idMarca.ToString +
                                " AND prod_coleccionid = " + idColeccion.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function contarEstilosColeccion(ByVal idColecicon As Int32) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dato As Int32 = 0
        Dim cadena As String = "SELECT" & _
                                " COUNT(1) ESTILOS" & _
                                " FROM Programacion.Productos P" & _
                                " JOIN Programacion.ProductoEstilo PE" & _
                                " ON P.prod_productoid = PE.pres_productoid" & _
                                " WHERE P.prod_activo = 1" & _
                                " AND PE.pres_activo = 1" & _
                                " AND P.prod_coleccionid = " & idColecicon.ToString
        Dim dt As New DataTable
        dt = operacion.EjecutaConsulta(cadena)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                dato = dt.Rows(0).Item("ESTILOS").ToString
            End If
        End If
        Return dato
    End Function

    Public Sub inactivarColeccionesClienteSicyCambioFamilia(ByVal marcaSicy As String, ByVal coleccionSIcy As String)
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim cadena As String
        cadena = "UPDATE Ventas.coleccionMarcaFamiliaCadenaAgente SET cmfa_activo = 0," & _
            " cmfa_fechaModificacion= GETDATE(), cmfa_usuarioModifico = " & Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString & _
            " WHERE cmfa_marcaSicy = '" & marcaSicy & _
            "' AND cmfa_coleccionSicy = '" & coleccionSIcy & _
            "' AND cmfa_activo = 1"
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub ejecutarRegistroCambioFamiliasAgenteColeccionSICY(ByVal idMarca As Int32, ByVal idFamilia As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@marcaId"
        ParametroParaLista.Value = idMarca
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@familia"
        ParametroParaLista.Value = idFamilia
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Ventas.SP_actualizarMarcaColeccionAgenteClienteSay", ListaParametros)
    End Sub

    Public Sub editarMarcaColeccionMismaFamilia(ByVal idMarca As Int32, ByVal coleccionSicy As String, ByVal idFamilia As Int32, ByVal idNaveDesarrolla As Integer, clasificacion As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE Programacion.ColeccionMarca SET"
        If idFamilia > 0 Then
            cadena += " coma_familiaproyeccionid = " & idFamilia.ToString & ", coma_idnavedesarrolla=" & idNaveDesarrolla
        Else
            cadena += " coma_familiaproyeccionid = NULL , coma_idnavedesarrolla=" & idNaveDesarrolla
        End If
        If clasificacion <> String.Empty Then
            cadena += ", coma_clasificacion = '" & clasificacion.ToString & "'"
        Else
            cadena += ", coma_clasificacion = NULL "
        End If

        cadena += ", coma_usuariomodificoid = " & Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString & _
        ", coma_fechamodificacion = GETDATE() WHERE coma_marcaid = " & idMarca.ToString & _
        " AND coma_codigosicy = '" & coleccionSicy & "'"
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Function ValidarConsumosColeccion(ByVal idColeccionMarca As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idColeccionMarca"
        ParametroParaLista.Value = idColeccionMarca
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Colecciones_ValidarConsumosColeccion]", ListaParametros)
    End Function

    Public Sub EditarColeccionDetalle2(ByVal idColeccion As Int32, ByVal idMarca As String,
                                      ByVal activoRelacion As Boolean, ByVal codigo As String,
                                      ByVal codSicy As String, ByVal existe As Int32,
                                      ByVal idCliente As Int32, ByVal idMarcYuyin As String,
                                      ByVal descripcionColeccionYuyin As String,
                                      ByVal idFamiliaProyeccion As String,
                                       ByVal lengualinea As Integer)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idColeccion"
        ParametroParaLista.Value = idColeccion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idMarca"
        ParametroParaLista.Value = idMarca
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activoRelacion"
        ParametroParaLista.Value = activoRelacion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@codigo"
        ParametroParaLista.Value = codigo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@codSicy"
        ParametroParaLista.Value = codSicy
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@existe"
        ParametroParaLista.Value = existe
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idCliente"
        If idCliente = 0 Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = idCliente
        End If
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idMarcYuyin"
        If idMarcYuyin = "0" Or idMarcYuyin = "" Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = idMarcYuyin
        End If
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@descripcionColeccionYuyin"
        If descripcionColeccionYuyin = "" Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = descripcionColeccionYuyin
        End If
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idFamiliaProyeccion"
        If idFamiliaProyeccion = "0" Or idFamiliaProyeccion = "" Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = idFamiliaProyeccion
        End If
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter("@lenguaLinea", lengualinea)
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_Coleccion_Detalle2", ListaParametros)
    End Sub

    Public Function EncontrarColeccionSICY(Opcion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim ListaParametros As New List(Of SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@Opcion"
        ParametroParaLista.Value = Opcion
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_CatalogoColecciones_EncontrarColeccionSICY]", ListaParametros)
    End Function

End Class
