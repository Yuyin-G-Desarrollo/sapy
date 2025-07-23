Imports Persistencia
Imports System.Data.SqlClient

Public Class MetodoPagoDA

    Public Function ListadoMetodoPago() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT mepa_metodopagoid, LTRIM(RTRIM(UPPER(mepa_nombre))) AS mepa_nombre FROM Cobranza.MetodoPago WHERE mepa_activo = 1 ORDER BY mepa_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    ''' <summary>
    ''' Ejecuta procedimiento almacenado que devuelve el método de pago para poblar los combos de Nota de crédito en la ficha técnica del cliente
    ''' </summary>
    ''' <returns></returns>
    Public Function ListaMetodoPago_NotaCredito() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutarConsultaSP("[Cliente].[SP_FichaTecnica_CreditoCobranza_MetodoPagoNotaCredito]", New List(Of SqlParameter))
    End Function

    Public Function ListaMetodoFormaPago_NotaCredito(ByVal clienteID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametros As New SqlParameter

        parametros.ParameterName = "@ClienteID"
        parametros.Value = clienteID
        listaParametros.Add(parametros)


        Return operaciones.EjecutarConsultaSP("[Cobranza].[SP_InfoCliente_ConsultaFormaMetodoPagoCliente_NotaCredito]", listaParametros)
    End Function


    Public Function Datos_TablaMetodoPago(clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT " +
                                "   mpcl_metodopagoclienteid" +
                                " , mpcl_clienteid" +
                                " , mepa_nombre, mpcl_activo  " +
                                " FROM Cobranza.MetodoPagoCliente " +
                                " JOIN Cobranza.MetodoPago ON mepa_metodopagoid = mpcl_metodopagoid " +
                                " WHERE  mpcl_clienteid = " + clienteID.ToString +
                                " order by mpcl_activo desc , mepa_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Sub altaMetodoPagoCliente(metodopagoid As Integer, clienteid As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@metodopagoid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "metodopagoid"
        parametro.Value = metodopagoid
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = clienteid
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cobranza.SP_Alta_MetodoPagoCliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub editarMetodoPagoCliente(metodopagoclienteid As Integer, metodopagoid As Integer, activo As Boolean)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@metodopagoclienteid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "metodopagoclienteid"
        parametro.Value = metodopagoclienteid
        listaParametros.Add(parametro)

        '@metodopagoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "metodopagoid"
        parametro.Value = metodopagoid
        listaParametros.Add(parametro)

        ',@activo AS BOOLEAN
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cobranza.SP_Editar_MetodoPagoCliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub



End Class
