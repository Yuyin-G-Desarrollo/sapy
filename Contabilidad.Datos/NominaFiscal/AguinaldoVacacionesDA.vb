Imports System.Data.SqlClient

Public Class AguinaldoVacacionesDA
    Public Function obtenerAniosPatron(ByVal patronId As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFAguinaldoVacaciones_ObtenerAniosPatron", listaParametros)
    End Function

    Public Function consultarAguinaldosVacaciones(ByVal patronId As Int32, ByVal anio As Integer, ByVal metodo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "porLey"
        parametro.Value = metodo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFAguinaldoVacaciones_ConsultarAguinaldosVacaciones", listaParametros)

    End Function

    Public Function validaAnioTimbrado(ByVal patronId As Int32, ByVal anio As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFAguinaldoVacaciones_ValidaAnioTimbrado", listaParametros)
    End Function

    Public Function validaTimbresFiscalesCompletos(ByVal patronId As Int32, ByVal anio As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFAguinaldoVacaciones_ValidaTimbresFiscales", listaParametros)
    End Function

    Public Sub calcularAguinaldoVacaciones(ByVal fechaCalculo As Date, ByVal patronId As Int32, ByVal porLey As Boolean, ByVal soloVacaciones As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Dim procedimiento As String = String.Empty

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCalculo"
        parametro.Value = fechaCalculo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "patron"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soloVacaciones"
        parametro.Value = soloVacaciones
        listaParametros.Add(parametro)

        If porLey Then
            procedimiento = "Contabilidad.SP_CalculoAguinaldoVacaciones_LeyISR_SoloVacaciones"
        Else
            procedimiento = "Contabilidad.SP_CalculoAguinaldoVacaciones_RLISR_SoloVacaciones"
        End If

        operacion.EjecutarConsultaSP(procedimiento, listaParametros)
    End Sub

    Public Function enviarTimbrar(ByVal patronId As Int32, ByVal anio As Integer, ByVal fechaPago As Date, ByVal soloVacaciones As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "PatronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaPago"
        parametro.Value = fechaPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soloVacaciones"
        parametro.Value = soloVacaciones
        listaParametros.Add(parametro)


        'Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_InsertarInformacionTimbradoAguinaldoVacaciones", listaParametros)
        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_InsertarInformacionTimbradoAguinaldoVacaciones4_0_Solovacaciones", listaParametros)
    End Function

    Public Function altaVacacionesAguinaldos(ByVal idCaja As Integer, ByVal tipoSolicitud As String,
                                             ByVal importe As Double, ByVal beneficiario As String,
                                             ByVal observaciones As String, ByVal razonsocial As String) As String
        Dim mensaje As String = "True"
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientosSICY
            Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
            Dim consulta As String = "DECLARE @Mensaje int "
            consulta += "EXEC usp_AltaVacacionesAguinaldosChequeFiscalCajaChica @Mensaje OUTPUT," + idCaja.ToString + ",'" + tipoSolicitud.ToString + "'," & importe & ",'" + beneficiario.ToString + "','" + observaciones.ToString + "','" + razonsocial.ToString + "' SELECT @Mensaje"
            operaciones.EjecutaConsulta(consulta)
        Catch ex As Exception
            Return ex.Message
        End Try
        Return mensaje
    End Function

    Public Function ConsultarCajaChicaPatron(ByVal patronId As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFAguinaldoVacaciones_ConsultarCajaChicaPatron", listaParametros)
    End Function
End Class
