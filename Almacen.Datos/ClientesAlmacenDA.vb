Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Persistencia

Public Class ClientesAlmacenDA

    Public Function CargarClientes() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "select b.Nombre as Agente,a.IdCadena, a.nombre from Cadenas as a left JOIN Agentes as b on (a.IdAgente = b.IdAgente) where a.Activo= 'S' ORDER BY a.nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListadoParametroUbicacion(tipo_busqueda As Integer, id_parametros As String) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        If tipo_busqueda = 1 Then
            consulta += " SELECT IdCodigo AS 'Parámetro',  CAST(0 AS BIT) AS ' ', IdModelo AS 'Modelo',Descripcion AS 'Descripción', Color AS 'Color' FROM vEstilos ORDER BY Descripcion, IdModelo, Color "
        Else
            If tipo_busqueda = 2 Then
                consulta += " SELECT IdCadena AS 'Parámetro', CAST(0 AS BIT) AS ' ', IdCadena AS 'Cadena', nombre AS 'Nombre' FROM vCadenas  WHERE Activo = 'S' ORDER BY nombre "
            Else
                If tipo_busqueda = 3 Then
                    consulta += " SELECT IdTalla AS 'Parámetro', CAST(0 AS BIT) AS ' ' , IdTalla AS 'Talla ID', Talla AS 'Talla' FROM tallas ORDER BY Talla "
                Else
                    If tipo_busqueda = 4 Then
                        Dim id_parametros_split As String() = id_parametros.ToString.Split(",")
                        consulta += " SELECT " +
                            "   bahi_bahiaid  AS 'Parámetro' " +
                            " , CAST(0 AS bit) AS ' ' " +
                            " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía' " +
                            " , bahi_bloque AS 'Bloque' " +
                            " , bahi_nivel 'Nivel' " +
                            " , bahi_segmento AS 'Segmento' " +
                            " , bahi_bahiaid AS 'Clave' " +
                            " FROM Almacen.Bahia" +
                            " WHERE bahi_activo = 1 AND bahi_nave IN (" + id_parametros_split(0) + ") AND bahi_almacen IN (" + id_parametros_split(1) + ")" +
                            " ORDER BY bahi_bloque, bahi_nivel, bahi_segmento, bahi_bahiaid "
                    Else
                        If tipo_busqueda = 5 Then
                            consulta += " SELECT IdNave AS 'Parámetro', CAST(0 AS BIT) AS ' ', Nave AS 'Nave' FROM Naves WHERE Activo = 1 ORDER BY Nave"
                        Else
                            If tipo_busqueda = 6 Then
                                consulta += " SELECT " +
                                    "   A.codr_colaboradorid AS 'Parámetro' " +
                                    " , CAST (0 AS bit) AS ' ' " +
                                    " , CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200)) AS 'Operador' " +
                                    " FROM [192.168.7.16].[YuyinERP_Calidad].[Nomina].[Colaborador] AS A " +
                                    " JOIN [192.168.7.16].[YuyinERP_Calidad].[Nomina].[ColaboradorLaboral] AS B ON B.labo_colaboradorid = A.codr_colaboradorid " +
                                    " JOIN [192.168.7.16].[YuyinERP_Calidad].[Framework].[Grupos] AS C ON C.grup_grupoid = B.labo_departamentoid " +
                                    " WHERE A.codr_activo = 1 AND C.grup_grupoid = 97 ORDER BY A.codr_nombre "
                            Else
                                If tipo_busqueda = 7 Then
                                    consulta += " SELECT IdAgente AS 'Parámetro', CAST(0 AS BIT) AS ' ', Nombre AS 'Nombre',Iniciales AS 'Iniciales' FROM Agentes WHERE Activo = 1 ORDER BY Nombre "
                                Else
                                    If tipo_busqueda = 8 Then
                                        Dim id_parametros_split As String() = id_parametros.ToString.Split(",")
                                        consulta += " SELECT DISTINCT CAST(0 AS integer) AS 'Parámetro', CAST(0 AS bit) AS ' ', bahi_descripcion AS 'Descripción de Bahía' " +
                                            " FROM Almacen.Bahia WHERE bahi_activo = 1 AND bahi_nave IN (" + id_parametros_split(0) + ") AND bahi_almacen IN (" + id_parametros_split(1) + ")" +
                                            " ORDER BY bahi_descripcion"
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListadoUbicacionAtado(mostrar_todo As Boolean, consultaPar As String, consultaAtado As String) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        If mostrar_todo Then
            consulta += consultaPar + " UNION " + consultaAtado
        Else
            If Not String.IsNullOrEmpty(consultaPar) And Not String.IsNullOrEmpty(consultaAtado) Then
                consulta += consultaPar + " UNION " + consultaAtado
            Else
                If Not String.IsNullOrEmpty(consultaPar) And String.IsNullOrEmpty(consultaAtado) Then
                    consulta += consultaPar
                Else
                    If String.IsNullOrEmpty(consultaPar) And Not String.IsNullOrEmpty(consultaAtado) Then
                        consulta += consultaAtado
                    End If
                End If
            End If
        End If

        consulta += "ORDER BY 'Fecha' DESC"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub AltaBahiaCliente(ByVal bahiacliente As Entidades.Bahia)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaValores As New List(Of SqlParameter)


        Dim valores As New SqlParameter
        valores.ParameterName = "bacl_bahiaid"
        valores.Value = bahiacliente.bahiaid
        listaValores.Add(valores)

        Try
            valores = New SqlParameter
            valores.ParameterName = "bacl_idcadena"
            valores.Value = bahiacliente.Cliente.Cadena
            listaValores.Add(valores)
        Catch ex As Exception

        End Try



        valores = New SqlParameter
        valores.ParameterName = "bacl_usuariocreoid"
        valores.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bacl_fechacreacion"
        valores.Value = Today.Date.ToShortDateString
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "bacl_activo"
        valores.Value = bahiacliente.Cliente.PActivo
        listaValores.Add(valores)





        operaciones.EjecutarSentenciaSP("Almacen.SP_AltaClienteAlmacen", listaValores)


    End Sub


    Public Function CargarClientesBahia(ByVal Bahiaid As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select * from Almacen.BahiaClientes as a join Almacen.Bahia as b " +
            "on a.bacl_bahiaid like '%'+b.bahi_bahiaid+'%' where a.bacl_bahiaid like '" + Bahiaid + "%'"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListadoCarritos(estatus As Integer, naveID As Integer, almacenID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        consulta += " SELECT CAST(0 AS BIT) AS ' ' ,carr_carritoid AS 'Párametro', carr_descripcion AS 'Plataforma', tica_tipocarritoid, tica_descripcion AS 'Tipo Plataforma' FROM Almacen.Carrito " +
            " JOIN Almacen.TipoCarrito ON carr_tipocarritoid = tica_tipocarritoid" +
            " WHERE carr_nave = " + naveID.ToString + "AND carr_almacen = " + almacenID.ToString + "AND carr_activo = " + estatus.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaTiposCarritos() As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT tica_tipocarritoid, tica_descripcion FROM Almacen.TipoCarrito WHERE tica_activo = 1 ORDER BY tica_descripcion"

        Return opereciones.EjecutaConsulta(consulta)
    End Function

    Public Sub Alta_Editar_Carrito(ByVal carrito As Entidades.Carrito)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ',@carritoid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "carritoid"
        parametro.Value = carrito.carritoid
        listaParametros.Add(parametro)

        ',@descripcion AS VARCHAR(30)
        parametro = New SqlParameter
        parametro.ParameterName = "descripcion"
        parametro.Value = carrito.descripcion
        listaParametros.Add(parametro)

        ',@naveid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "naveid"
        parametro.Value = carrito.nave.PNaveId
        listaParametros.Add(parametro)

        ',@almacenid	AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "almacenid"
        parametro.Value = carrito.almacen.almacenid
        listaParametros.Add(parametro)

        ',@tipocarritoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipocarritoid"
        parametro.Value = carrito.tipocarrito.tipocarritoid
        listaParametros.Add(parametro)

        ',@estatus AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "estatus"
        parametro.Value = carrito.activo
        listaParametros.Add(parametro)

        ',@usuarioid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Almacen.SP_Alta_Edicion_Carritos", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Almacen_ReporteProductividadPlataforma(sentencia As String) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = sentencia

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Almacen_ReporteHistoricoUbicaciones(sentencia As String) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = sentencia

        Return operaciones.EjecutaConsulta(consulta)

    End Function



    Public Function ListaAgentes() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select * from Agentes where Activo =1 "
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function ListaClientesSegunAgente(ByVal idAgente As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = String.Empty
        Consulta = "select * from Cadenas where IdAgente=" + idAgente.ToString
        Return operaciones.EjecutaConsulta(Consulta)
    End Function



End Class
