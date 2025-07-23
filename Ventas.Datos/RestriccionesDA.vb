Imports Persistencia
Imports System.Data.SqlClient

Public Class RestriccionesDA

    Public Function ListadoRestriccionesFacturacion() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT rest_restriccionid, LTRIM(RTRIM(UPPER(rest_nombre))) AS rest_nombre FROM Ventas.Restriccion JOIN Ventas.TipoRestriccion ON rest_tiporestriccionid = tire_tiporestriccionid WHERE tire_tiporestriccionid = 1 AND rest_activo = 1 ORDER BY rest_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub editarRestriccionCliente(ByVal restriccion As Entidades.RestriccionCliente, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@bandera AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@valor AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "valor"
        If restriccion.valor = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = restriccion.valor
        End If
        listaParametros.Add(parametro)

        ',@descripcion AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "descripcion"
        If String.IsNullOrWhiteSpace(restriccion.descripcion) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = restriccion.descripcion
        End If
        listaParametros.Add(parametro)

        ',@restriccionid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "restriccionid"
        If IsNothing(restriccion.restriccion) Then
            parametro.Value = 0
        Else
            parametro.Value = restriccion.restriccion.restriccionid
        End If
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = restriccion.cliente.clienteid
        listaParametros.Add(parametro)

        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        If restriccion.activo Then
            parametro.Value = False
        Else
            parametro.Value = restriccion.activo
        End If
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_RestriccionCliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaRestriccionesCliente(clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT * FROM Ventas.RestriccionCliente WHERE recl_clienteid = " + clienteID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function


End Class
