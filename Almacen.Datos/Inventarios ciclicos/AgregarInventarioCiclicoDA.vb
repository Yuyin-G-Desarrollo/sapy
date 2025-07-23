Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class AgregarInventarioCiclicoDA

    Public Function RecuperarNombreCliente(ByVal IdCliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "Select nombre as nombre from vCadenas where IdCadena in (" + IdCliente + ") order by nombre"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function RecuperarNombreAgente(ByVal IdAgente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select Nombre from Agentes where IdAgente in (" + IdAgente + ")"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function RecuperarNombreTienda(ByVal IdTienda As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select distribucion as Tienda from vCadenasDistribucion where IdDistribucion IN (" + IdTienda + ")"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function RecuperarNombreProducto(ByVal IdProducto As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select descripcion as 'Descripcion' from vEstilos where IdCodigo in (" + IdProducto + ")"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function RecuperarNombreBahia(ByVal IdBahia As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "SELECT LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía' FROM Almacen.Bahia WHERE bahi_bahiaid in (" + IdBahia + ") order by 'Bahía'"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    Public Function RecuperarDescripcionCorrida(ByVal IdCorrida As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "SELECT  Talla AS 'Talla' FROM tallas where IdTalla in (" + IdCorrida + ") ORDER BY Talla"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    Public Function RecuperarMarca(ByVal IdMarca As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "select Marca from marcas where IdMarca in (" + IdMarca + ") order by Marca"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    Public Function RecuperarColeccion(ByVal IdColeccion As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "select coleccion from Colecciones where IdColeccion in (" + IdColeccion + ") order by Coleccion"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    Public Function ListaOperadores() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "SELECT A.codr_colaboradorid AS 'Parámetro' " +
        " , CAST (0 AS bit) AS ' ' " +
        " , CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200)) AS 'Operador' " +
        " FROM [Nomina].[Colaborador] AS A " +
        " JOIN [Nomina].[ColaboradorLaboral] AS B ON B.labo_colaboradorid = A.codr_colaboradorid " +
        " JOIN [Framework].[Grupos] AS C ON C.grup_grupoid = B.labo_departamentoid " +
        " WHERE A.codr_activo = 1 AND C.grup_grupoid = 97 ORDER BY A.codr_nombre"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


    Public Sub AgregarInventarioCiclico(ByVal InventarioCiclico As Entidades.InventariosCiclicos)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@tico_nombre"
        parametro.Value = InventarioCiclico
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tico_activo"
        parametro.Value = InventarioCiclico
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tico_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_TipoCondicion", listaparametros)
    End Sub


End Class
