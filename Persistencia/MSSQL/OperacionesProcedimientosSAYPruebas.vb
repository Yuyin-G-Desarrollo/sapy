Imports System.Data.SqlClient
Imports Entidades

''' <summary>
''' Clase de la capa de persistencia para ejecutar operaciones a la base de datos 
''' </summary>
''' <Autor>Juan Alejandro Resendiz Villanueva</Autor>
''' <Fecha>20/06/2013</Fecha>
Public Class OperacionesProcedimientosSAYPruebas

    Dim Conexion As New Pool(0)

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

            If Not (Parametros Is Nothing) Then
                For Each Para As SqlParameter In Parametros
                    ComandoSql.Parameters.Add(Para)
                Next
            End If

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
    ''' Funcion para obtener datos de la base de datos a partir de una consulta
    ''' </summary>
    ''' <param name="ConsultaSql">Indica la consulta de seleccion de registros.</param>
    ''' <returns>Regresa una datatable con la informacion de la consulta</returns>
    ''' <remarks></remarks>
    Public Function EjecutaConsulta(ByVal ConsultaSql As String) As Data.DataTable
        Try


            Dim ComandoSql As New SqlCommand
            Dim sda As New SqlDataAdapter
            EjecutaConsulta = New DataTable

            With ComandoSql
                .CommandText = ConsultaSql
                .CommandType = CommandType.Text
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
    ''' Funcion para ejecutar operaciones de insert, update, delete sobre la base de datos a partir de una consulta
    ''' </summary>
    ''' <param name="ConsultaSql">Indica la consulta de actualizacion de la base de datos</param>
    ''' <returns>
    ''' Regresa el numero de registros actualizados.</returns>
    ''' <remarks></remarks>
    Public Function EjecutaSentencia(ByVal ConsultaSql As String) As Int32
        Try

            Dim ComandoSql As New SqlCommand
            EjecutaSentencia = 0

            With ComandoSql
                .CommandText = ConsultaSql
                .CommandType = CommandType.Text
                .Connection = Conexion.SQLConn
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
    ''' Funcion para obtener datos desde la base de datos a partir de un objeto command
    ''' </summary>
    ''' <param name="cmd">comando desde donde se va a obtener los datos</param>
    ''' <returns>regresa un objeto de tipo datatable con los datos consultados</returns>
    ''' <remarks></remarks>
    Public Function EjecutaCmdConsulta(ByVal cmd As SqlCommand) As DataTable
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
    Public Function EjecutaCmdSentencia(ByVal cmd As SqlCommand) As Int32
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



    Public Function EjecutacmdTransaccion(ByVal cmd As List(Of SqlCommand)) As Int32
        Dim Transaccion As SqlTransaction

        Try

            EjecutacmdTransaccion = 0
            Conexion.SQLConn.Open()
            Transaccion = Conexion.SQLConn.BeginTransaction()

            For Each comando As SqlCommand In cmd
                comando.Connection = Conexion.SQLConn
                comando.Transaction = Transaccion
                EjecutacmdTransaccion += comando.ExecuteNonQuery
            Next

            Transaccion.Commit()

            Conexion.SQLConn.Close()

            Return EjecutacmdTransaccion

        Catch sqlex As SqlClient.SqlException
            Try
                Transaccion.Rollback()
            Catch ex As Exception
                Throw ex
            End Try
            Throw sqlex
        Catch ex As Exception
            Try
                Transaccion.Rollback()
            Catch ex2 As Exception
                Throw ex2
            End Try
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

End Class