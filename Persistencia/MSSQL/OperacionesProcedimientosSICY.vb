Imports System.Data.SqlClient
Imports Entidades

''' <summary>
''' Clase de la capa de persistencia para ejecutar operaciones a la base de datos de SICY (Copia Editada)
''' </summary>
''' <Autor>Miguel Angel Lucio Reyes</Autor>
''' <Fecha>13/08/2013</Fecha>
Public Class OperacionesProcedimientosSICY

    Dim Conexion As New Pool(True)

    ''' <summary>
    ''' Funcion que ejecuta un procedimiento almacenado para obtener datos desde la base de datos
    ''' </summary>
    ''' <param name="NombreSP">Nombre del procedimiento almacenado</param>
    ''' <param name="Parametros">Coleccion de parametros usados por el procedimientos</param>
    ''' <returns>Regresa un objeto de tipo tabla con los registros encontrados</returns>
    ''' <remarks></remarks>
    Public Function EjecutarConsultaSP(ByVal NombreSP As String, ByVal Parametros As List(Of SqlParameter)) As DataTable
        Try

            Dim StatusEjecucion As Int32 = 0
            Dim MensajeEjecucion As String = String.Empty
            Dim DtSeleccion = New DataTable
            EjecutarConsultaSP = New DataTable

            Dim ComandoSql As New SqlCommand(NombreSP, Conexion.SQLConn)
            ComandoSql.CommandType = CommandType.StoredProcedure
            ComandoSql.CommandTimeout = 300000



            For Each Para As SqlParameter In Parametros
                ComandoSql.Parameters.Add(Para)
            Next


            Conexion.SQLConn.Open()

            Dim sda As New SqlDataAdapter
            sda.SelectCommand = ComandoSql
            sda.Fill(DtSeleccion)
            DtSeleccion.TableName = NombreSP

            Conexion.SQLConn.Close()


            Return DtSeleccion

        Catch sqlex As SqlClient.SqlException
            'Throw New Exception(ErroresPersistencia.Guardar(sqlex, NombreSP, Parametros))
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Funcion que ejecuta un procedimiento almacenado para obtener datos desde la base de datos y guarda registro de la accion en la bitacora
    ''' </summary>
    ''' <param name="NombreSP">Nombre del procedimiento almacenado</param>
    ''' <param name="Parametros">Coleccion de parametros usados por el procedimientos</param>
    ''' <returns>Regresa un objeto de tipo tabla con los registros encontrados</returns>
    ''' <remarks></remarks>
    Public Function EjecutarConsultaSPConBitacora(ByVal NombreSP As String, ByVal Parametros As List(Of SqlParameter), ByVal accionid As Integer, ByVal UsuarioId As Integer, ByVal ubicacion As String) As DataTable
        Try
            Dim cadenaAccion As String = NombreSP + " "
            Dim StatusEjecucion As Int32 = 0
            Dim MensajeEjecucion As String = String.Empty
            Dim DtSeleccion = New DataTable
            EjecutarConsultaSPConBitacora = New DataTable

            Dim ComandoSql As New SqlCommand(NombreSP, Conexion.SQLConn)
            ComandoSql.CommandType = CommandType.StoredProcedure
            ComandoSql.CommandTimeout = 300000

            If Not (Parametros Is Nothing) Then
                For Each Para As SqlParameter In Parametros
                    ComandoSql.Parameters.Add(Para)
                    cadenaAccion += Para.Value.ToString + ","
                Next
            End If

            Conexion.SQLConn.Open()
            Dim sda As New SqlDataAdapter
            sda.SelectCommand = ComandoSql
            sda.Fill(DtSeleccion)
            DtSeleccion.TableName = NombreSP

            Conexion.SQLConn.Close()

            insertaBitacoraAcciones(cadenaAccion, accionid, UsuarioId, ubicacion)

            Return DtSeleccion

        Catch sqlex As SqlClient.SqlException
            'Throw New Exception(ErroresPersistencia.Guardar(sqlex, NombreSP, Parametros))
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Funcion que ejecuta un procedimiento almacenado que a su vez ejecuta operaciones de insert, update, delete sobre la base de datos
    ''' </summary>
    ''' <param name="NombreSP">Nombre del procedimiento almacenado</param>
    ''' <param name="Parametros">Coleccion de parametros usados por el procedimientos</param>
    ''' <returns>Regresa la cantidad de registros afectados por las operaciones</returns>
    ''' <remarks></remarks>
    Public Function EjecutarSentenciaSP(ByVal NombreSP As String, ByVal Parametros As List(Of SqlParameter)) As Int32
        Try

            EjecutarSentenciaSP = 0

            Dim ComandoSql As New SqlCommand(NombreSP, Conexion.SQLConn)
            ComandoSql.CommandType = CommandType.StoredProcedure
            ComandoSql.CommandTimeout = 300000

            For Each Para As SqlParameter In Parametros
                ComandoSql.Parameters.Add(Para)
            Next

            Conexion.SQLConn.Open()

            EjecutarSentenciaSP = ComandoSql.ExecuteNonQuery
            Conexion.SQLConn.Close()

            Return EjecutarSentenciaSP 'DtSeleccion

        Catch sqlex As SqlClient.SqlException
            Throw New Exception(ErroresPersistencia.Guardar(sqlex, NombreSP, Parametros))
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    ''' <summary>
    ''' Funcion que ejecuta un procedimiento almacenado que a su vez ejecuta operaciones de insert, update, delete sobre la base de datos. Guarda registro de la accion en bitacora
    ''' Guarda bitacora
    ''' </summary>
    ''' <param name="NombreSP">Nombre del procedimiento almacenado</param>
    ''' <param name="Parametros">Coleccion de parametros usados por el procedimientos</param>
    ''' <returns>Regresa la cantidad de registros afectados por las operaciones</returns>
    ''' <remarks></remarks>
    Public Function EjecutarSentenciaSPConBitacora(ByVal NombreSP As String, ByVal Parametros As List(Of SqlParameter), ByVal accionid As Integer, ByVal UsuarioId As Integer, ByVal ubicacion As String) As Int32
        Try
            Dim cadenaAccion As String = NombreSP + " "
            EjecutarSentenciaSPConBitacora = 0

            Dim ComandoSql As New SqlCommand(NombreSP, Conexion.SQLConn)
            ComandoSql.CommandType = CommandType.StoredProcedure

            For Each Para As SqlParameter In Parametros
                ComandoSql.Parameters.Add(Para)
                cadenaAccion += Para.Value.ToString + ","
            Next

            Conexion.SQLConn.Open()

            EjecutarSentenciaSPConBitacora = ComandoSql.ExecuteNonQuery
            Conexion.SQLConn.Close()


            insertaBitacoraAcciones(cadenaAccion, accionid, UsuarioId, ubicacion)

            Return EjecutarSentenciaSPConBitacora 'DtSeleccion

        Catch sqlex As SqlClient.SqlException
            Throw New Exception(ErroresPersistencia.Guardar(sqlex, NombreSP, Parametros))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Funcion para obtener datos de la base de datos a partir de una consulta
    ''' </summary>
    ''' <param name="ConsultaSql">Indica la consulta de seleccion de registros.</param>
    ''' <returns>Regresa una datatable con la informacion de la consulta</returns>
    ''' <remarks></remarks>
    Public Function EjecutaConsulta(ConsultaSql As String) As Data.DataTable
        Try


            Dim ComandoSql As New SqlCommand
            Dim sda As New SqlDataAdapter
            EjecutaConsulta = New DataTable

            With ComandoSql
                .CommandText = ConsultaSql
                .CommandType = CommandType.Text
                .CommandTimeout = 300000
                .Connection = Conexion.SQLConn
            End With

            Conexion.SQLConn.Open()

            sda.SelectCommand = ComandoSql
            sda.Fill(EjecutaConsulta)
            Conexion.SQLConn.Close()

            Return EjecutaConsulta

        Catch sqlex As SqlClient.SqlException
            SesionError.CargarError(ConsultaSql, sqlex)
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Funcion para obtener datos de la base de datos a partir de una consulta
    ''' </summary>
    ''' <param name="ConsultaSql">Indica la consulta de seleccion de registros.</param>
    ''' <returns>Regresa una datatable con la informacion de la consulta</returns>
    ''' <remarks></remarks>
    Public Function EjecutaConsultaSinThrow(ConsultaSql As String) As Data.DataTable

        Dim ComandoSql As New SqlCommand
        Dim sda As New SqlDataAdapter
        EjecutaConsultaSinThrow = New DataTable

        With ComandoSql
            .CommandText = ConsultaSql
            .CommandType = CommandType.Text
            .Connection = Conexion.SQLConn
            .CommandTimeout = 300000
        End With

        Conexion.SQLConn.Open()

        sda.SelectCommand = ComandoSql
        sda.Fill(EjecutaConsultaSinThrow)
        Conexion.SQLConn.Close()

        Return EjecutaConsultaSinThrow
  
    End Function

    ''' <summary>
    ''' Funcion para obtener datos de la base de datos a partir de una consulta y guarda registro en la bitacora de acciones
    ''' </summary>
    ''' <param name="ConsultaSql">Indica la consulta de seleccion de registros.</param>
    ''' <returns>Regresa una datatable con la informacion de la consulta</returns>
    ''' <remarks></remarks>
    Public Function EjecutaConsultaConBitacora(ConsultaSql As String, ByVal accionid As Integer, ByVal UsuarioId As Integer, ByVal ubicacion As String) As Data.DataTable
        Try
            Dim cadenaAccion As String = ConsultaSql

            Dim ComandoSql As New SqlCommand
            Dim sda As New SqlDataAdapter
            EjecutaConsultaConBitacora = New DataTable

            With ComandoSql
                .CommandText = ConsultaSql
                .CommandType = CommandType.Text
                .Connection = Conexion.SQLConn
            End With

            Conexion.SQLConn.Open()

            sda.SelectCommand = ComandoSql
            sda.Fill(EjecutaConsultaConBitacora)
            Conexion.SQLConn.Close()


            insertaBitacoraAcciones(cadenaAccion, accionid, UsuarioId, ubicacion)

            Return EjecutaConsultaConBitacora

        Catch sqlex As SqlClient.SqlException
            SesionError.CargarError(ConsultaSql, sqlex)
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Funcion para ejecutar operaciones de insert, update, delete sobre la base de datos a partir de una consulta
    ''' </summary>
    ''' <param name="ConsultaSql">Indica la consulta de actualizacion de la base de datos</param>
    ''' <returns>
    ''' Regresa el numero de registros actualizados.</returns>
    ''' <remarks></remarks>
    Public Function EjecutaSentencia(ConsultaSql As String) As Int32
        Try

            Dim ComandoSql As New SqlCommand
            EjecutaSentencia = 0

            With ComandoSql
                .CommandText = ConsultaSql
                .CommandType = CommandType.Text
                .Connection = Conexion.SQLConn
                .CommandTimeout = 300000
            End With

            Conexion.SQLConn.Open()

            EjecutaSentencia = ComandoSql.ExecuteNonQuery()

            Conexion.SQLConn.Close()

            Return EjecutaSentencia


        Catch sqlex As SqlClient.SqlException
            SesionError.CargarError(ConsultaSql, sqlex)
            Throw sqlex
        Catch ex As Exception
            SesionError.Sentencia = ConsultaSql
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Funcion para ejecutar operaciones de insert, update, delete sobre la base de datos a partir de una consulta y guarda registro en la bitacora de acciones
    ''' </summary>
    ''' <param name="ConsultaSql">Indica la consulta de actualizacion de la base de datos</param>
    ''' <returns>
    ''' Regresa el numero de registros actualizados.</returns>
    ''' <remarks></remarks>
    Public Function EjecutaSentenciaConBitacora(ConsultaSql As String, ByVal accionid As Integer, ByVal UsuarioId As Integer, ByVal ubicacion As String) As Int32
        Try
            Dim cadenaAccion As String = ConsultaSql
            Dim ComandoSql As New SqlCommand
            EjecutaSentenciaConBitacora = 0

            With ComandoSql
                .CommandText = ConsultaSql
                .CommandType = CommandType.Text
                .Connection = Conexion.SQLConn
            End With

            Conexion.SQLConn.Open()

            EjecutaSentenciaConBitacora = ComandoSql.ExecuteNonQuery()

            Conexion.SQLConn.Close()

            insertaBitacoraAcciones(cadenaAccion, accionid, UsuarioId, ubicacion)

            Return EjecutaSentenciaConBitacora


        Catch sqlex As SqlClient.SqlException
            SesionError.CargarError(ConsultaSql, sqlex)
            Throw sqlex
        Catch ex As Exception
            SesionError.Sentencia = ConsultaSql
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Funcion para obtener datos desde la base de datos a partir de un objeto command
    ''' </summary>
    ''' <param name="cmd">comando desde donde se va a obtener los datos</param>
    ''' <returns>regresa un objeto de tipo datatable con los datos consultados</returns>
    ''' <remarks></remarks>
    Public Function EjecutaCmdConsulta(cmd As SqlCommand) As DataTable
        Try

            EjecutaCmdConsulta = New DataTable

            With cmd
                .Connection = Conexion.SQLConn
            End With

            Conexion.SQLConn.Open()

            Dim da As New SqlDataAdapter(cmd)
            da.Fill(EjecutaCmdConsulta)

            Conexion.SQLConn.Close()


            Return EjecutaCmdConsulta

        Catch sqlex As SqlClient.SqlException
            Throw New Exception(ErroresPersistencia.Guardar(sqlex, cmd.ToString, New List(Of SqlParameter)))
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Funcion  para ejecutar operaciones de insert, update, delete sobre la base de datos a partir de un objeto command
    ''' </summary>
    ''' <param name="cmd">Comando que contiene las operaciones de actualizacion</param>
    ''' <returns>Numero de registros actualizados</returns>
    ''' <remarks></remarks>
    Public Function EjecutaCmdSentencia(cmd As SqlCommand) As Int32
        Try

            EjecutaCmdSentencia = 0

            With cmd
                .Connection = Conexion.SQLConn
            End With

            Conexion.SQLConn.Open()

            EjecutaCmdSentencia = cmd.ExecuteNonQuery

            Conexion.SQLConn.Close()


            Return EjecutaCmdSentencia

        Catch sqlex As SqlClient.SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    ''' <summary>
    ''' Funcion para obtener un valor escalar de la base de datos a partir de una consulta
    ''' </summary>
    ''' <param name="ConsultaSql">Indica la consulta de seleccion de registros.</param>
    ''' <returns>Regresa una datatable con la informacion de la consulta</returns>
    ''' <remarks></remarks>
    Public Function EjecutaConsultaEscalar(ByVal ConsultaSql As String) As Object
        Try


            Dim ComandoSql As New SqlCommand



            With ComandoSql
                .CommandText = ConsultaSql
                .CommandType = CommandType.Text
                .Connection = Conexion.SQLConn
            End With

            Conexion.SQLConn.Open()

            EjecutaConsultaEscalar = ComandoSql.ExecuteScalar

            Conexion.SQLConn.Close()

            Return EjecutaConsultaEscalar

        Catch sqlex As SqlClient.SqlException
            SesionError.CargarError(ConsultaSql, sqlex)
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub insertaBitacoraAcciones(ByVal sentencia As String, ByVal accionid As Integer, ByVal usuarioid As Integer, ByVal ubicacion As String)
        'EJECUTA INSERT EN LA BITACORA DE ACCIONES
        Try

            Dim operacionesERP As New OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)

            Dim parametro As New SqlParameter
            parametro.ParameterName = "@cadenaConsulta"
            parametro.Value = sentencia
            listaParametros.Add(parametro)

            ',@valor AS INTEGER
            parametro = New SqlParameter
            parametro.ParameterName = "@AccionId"
            parametro.Value = accionid
            listaParametros.Add(parametro)

            ',@descripcion AS INTEGER
            parametro = New SqlParameter
            parametro.ParameterName = "@ubicacion"
            parametro.Value = ubicacion
            listaParametros.Add(parametro)

            ',@condicioncatalogoid AS INTEGER
            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = usuarioid
            listaParametros.Add(parametro)

            operacionesERP.EjecutarSentenciaSP("Framework.SP_RegistroBitacioraAcciones", listaParametros)

        Catch ex As Exception

        End Try

    End Sub


    Public Function Servidor() As String
        Servidor = "MUNICH"
        Dim cadena As String = My.Settings.CadenaConexionPoolSICY
        Dim elementos As String() = cadena.Split(CChar(";"))
        Dim word As String
        For Each word In elementos
            If word.ToUpper.Contains("DATA SOURCE") Then
                Servidor = word.Replace("Data Source=", "")
            End If
        Next
        Servidor = Servidor.Trim()
    End Function

    Public Function NombreDB() As String
        NombreDB = "Yuyin"
        Dim cadena As String = My.Settings.CadenaConexionPoolSICY
        Dim elementos As String() = cadena.Split(CChar(";"))
        Dim word As String
        For Each word In elementos
            If word.ToUpper.Contains("INITIAL CATALOG") Then
                NombreDB = word.Replace("Initial Catalog=", "")
            End If
        Next
        NombreDB = NombreDB.Trim()
    End Function

End Class

