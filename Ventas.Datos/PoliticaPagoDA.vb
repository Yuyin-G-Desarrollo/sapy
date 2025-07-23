Imports Persistencia
Imports System.Data.SqlClient

Public Class PoliticaPagoDA

    Public Sub editarPoliticaPago(ByVal PoliticaPago As Entidades.PoliticaPago, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "parcialidades1"
        If PoliticaPago.parcialidades1 = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaPago.parcialidades1
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "parcialidadesx"
        If PoliticaPago.parcialidadesx = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaPago.parcialidadesx
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "metodopagoid"
        If IsNothing(PoliticaPago.metodopago) Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = PoliticaPago.metodopago.metodopagoid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "formapagoid"
        If IsNothing(PoliticaPago.formapago) Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = PoliticaPago.formapago.formapagoid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "imprimirficharap"
        If PoliticaPago.imprimirficharap Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaPago.imprimirficharap
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "plazoreal"
        If PoliticaPago.plazoreal = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaPago.plazoreal
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "notascobranza"
        If String.IsNullOrWhiteSpace(PoliticaPago.notascobranza) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = PoliticaPago.notascobranza
        End If
        listaParametros.Add(parametro)

        ',@notasdevoluciones AS VARCHAR(200)
        parametro = New SqlParameter
        parametro.ParameterName = "notasdevoluciones"
        If String.IsNullOrWhiteSpace(PoliticaPago.notasdevoluciones) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = PoliticaPago.notasdevoluciones
        End If
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = PoliticaPago.cliente.clienteid
        listaParametros.Add(parametro)

        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        If PoliticaPago.activo Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaPago.activo
        End If
        listaParametros.Add(parametro)

        ',@usuariomodificoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        ',@proporcionarCuentaRemisiones AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "proporcionarCuentaRemisiones"
        parametro.Value = PoliticaPago.proporcionarcuentaremision
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cobranza.SP_Editar_PoliticaPago", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaPoliticaPago(ByVal clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT * FROM Cobranza.PoliticaPago WHERE popa_clienteid = " + clienteID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function editarNumReferenciayConvenio(cliente As Integer, numeroRef As String, convenio As String) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@clienteid"
        parametro.Value = cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@numReferencia"
        parametro.Value = numeroRef
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@convenio"
        parametro.Value = convenio
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Ventas.SP_FTC_AgregarNumReferenciaAndConvenio", listaParametros)

    End Function

    Public Function AltaEdicionPeriodicidadEnvioEstadosCuenta(ByVal clienteId As Integer, tipoPeriodicidad As Integer, ByVal mostrarFacturas As Boolean, ByVal mostrarRemisiones As Boolean) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@clienteid", clienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@periodicidadid", tipoPeriodicidad)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioid", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@mostrarFacturas", mostrarFacturas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@mostrarRemisiones", mostrarRemisiones)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_AltaEdicion_PeriodicidadEnvioEstadoDeCuentaClientes]", listaParametros)
    End Function

    Public Function ObtenerPeriodicidadEnvioEstadosCuenta(ByVal clienteId As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@clienteid", clienteId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_ObtenerPeriodicidad_EnvioEstadoDeCuentaClientes]", listaParametros)
    End Function

End Class
